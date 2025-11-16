using UnityEngine;
using System;
using BeardedManStudios.Network;
using BeardedManStudios.Network.Unity;

[ScriptOrder(-50)]
public class MainMenuNetworkManager : MonoBehaviour {
    public int defaultPort = 15937;
    public string masterServerIp = "127.0.0.1";
    public float packetDropSimulationChance = 0.0f;                 // A number between 0 and 1 where 0 is 0% and 1 is 100%
    public int serverLatencySimulation = 0;
    public int clientLatencySimulation = 0;
    public Networking.TransportationProtocolType protocolType = Networking.TransportationProtocolType.UDP;

    private NetWorker socket = null;

    private string sceneName;
    private MapConverter mapConverter;

    public static MainMenuNetworkManager instance;

    void Awake() {
        instance = this;
        mapConverter = new MapConverter();
        ForgeMasterServer.SetIp(masterServerIp);
#if UNITY_STANDALONE_LINUX
        Settings.instance.standalone.isStandalone = true;
#endif
    }

    void Start() {
        if (Settings.instance.standalone.isStandalone) {
            Networking.InitializeFirewallCheck((ushort)Settings.instance.standalone.port);
        }
        else {
            Networking.InitializeFirewallCheck((ushort)defaultPort);
        }

        if (Settings.instance.standalone.isStandalone && ApplicationManager.isInMainMenu()) {
            MapEnum mapEnum = mapConverter.convert(Settings.instance.standalone.sceneName);
            masterServerIp = Settings.instance.standalone.masterServerIP;
            createServer(Settings.instance.standalone.port, Settings.instance.standalone.maxPlayer, Settings.instance.standalone.serverName, mapEnum);
            return;
        }
    }

    public void createServer(int maxPlayers, string serverName, MapEnum mapEnum) {
        createServer(defaultPort, maxPlayers, serverName, mapEnum);
    }

    private void createServer(int port, int maxPlayers, string serverName, MapEnum mapEnum) {
        LoadingScreen.instance.show("Creating Server");
        sceneName = mapConverter.convert(mapEnum);
        socket = Networking.Host((ushort)port, protocolType, maxPlayers);
        if (mapEnum == MapEnum.TEST_MAP) {
            socket.TrackBandwidth = false;
        }
        registerSimulationServer();

        registerSocketError();
        registerConnectTimeout();
        registerNetworkReset();
        registerServerDisconnected();
        registerToMasterSever(maxPlayers, serverName, port, mapEnum);
        registerLoadScene();
    }

    public void joinServer(HostInfo hostInfo) {
        sceneName = hostInfo.sceneName;
        LoadingScreen.instance.show("Joining Server");
        socket = Networking.Connect(hostInfo.ipAddress, hostInfo.port, protocolType);
        if (mapConverter.convert(hostInfo.sceneName) == MapEnum.TEST_MAP) {
            socket.TrackBandwidth = true;
        }
        registerSimulationClient();

        registerSocketError();
        registerConnectTimeout();
        registerNetworkReset();
        registerServerDisconnected();

        registerLoadScene();
    }

    public void getHosts(Action<HostInfo[]> callback) {
        ForgeMasterServer.GetHosts(masterServerIp, 0, callback);
    }

    private void registerToMasterSever(int maxPlayers, string serverName, int port, MapEnum mapEnum) {
        if (!string.IsNullOrEmpty(masterServerIp)) {
            socket.connected += delegate () {
                ForgeMasterServer.RegisterServer(masterServerIp, (ushort)port, maxPlayers, serverName, sceneName: sceneName);
            };
            socket.playerConnected += updatePlayerCount;
            socket.playerDisconnected += updatePlayerCount;
        }
    }

    private void updatePlayerCount(NetworkingPlayer player) {
        ForgeMasterServer.UpdateServer(masterServerIp, socket.Port, socket.Players.Count);
    }

    private void registerSimulationServer() {
#if !NETFX_CORE
        if (socket is CrossPlatformUDP) {
            ((CrossPlatformUDP)socket).packetDropSimulationChance = packetDropSimulationChance;
            ((CrossPlatformUDP)socket).NetworkLatencySimulationTime = serverLatencySimulation;
        }
#endif
    }

    private void registerSimulationClient() {
#if !NETFX_CORE
        if (socket is CrossPlatformUDP) {
            ((CrossPlatformUDP)socket).NetworkLatencySimulationTime = clientLatencySimulation;
        }
#endif
    }

    private void registerServerDisconnected() {
        socket.serverDisconnected += (reason) => serverDisconnected(reason);
    }

    private void serverDisconnected(string reason) {
        showErrorInMainMenu("NETWORK ERROR", "The server kicked you for reason:\n" + reason);
    }

    private void registerSocketError() {
        socket.error += socketError;
    }

    private void socketError(Exception exception) {
        string header = "";
        if (exception is Exception) {
            header = "SYSTEM ERROR";
            Debug.LogWarning("It is a system exception");
        }
        else if (exception is NetworkException) {
            header = "NETWORK ERROR";
            Debug.LogWarning("This is a Forge Networking specific exception");
        }
#if !NETFX_CORE
        else if (exception is System.Net.Sockets.SocketException) {
            header = "SOCKET ERROR";
            Debug.LogWarning("This is somekind of socket exception, could be that the port is already in use?");
        }
#endif
        else {
            header = "ERROR";
            Debug.LogWarning("What is this exception?");
        }

        Debug.LogException(exception);

        Networking.NetworkingReset();
        Networking.Disconnect();
        showErrorInMainMenu(header, exception.ToString());
    }

    private void registerNetworkReset() {
        Networking.NetworkReset += resetSocket;
    }

    private void resetSocket() {
        socket = null;
        Networking.NetworkReset -= resetSocket;
    }

    private void registerConnectTimeout() {
        if (!socket.Connected) {
            socket.ConnectTimeout = 5000;
            socket.connectTimeout += connectTimeout;
        }
    }

    private void connectTimeout() {
        Networking.Disconnect();
        showErrorInMainMenu("NETWORK ERROR", "Connection Timeout");
    }

    private void registerLoadScene() {
        if (socket.Connected) {
            loadScene();
        }
        else {
            socket.connected += loadScene;
        }
    }

    private void loadScene() {
        LoadingScreen.instance.show("Loading Scene");
        socket.connected -= loadScene;
        setPrimarySocket();
        ApplicationManager.goToScene(sceneName);
    }

    private void registerSetSocket() {
        if (socket.Connected) {
            setPrimarySocket();
        }
        else {
            socket.connected += setPrimarySocket;
        }
    }

    private void setPrimarySocket() {
        Networking.SetPrimarySocket(socket);
    }


    private static void showErrorInMainMenu(string header, string context) {
        MainThreadManager.Run(() => {
            if (ApplicationManager.isInMainMenu()) {
                MainMenuManager.instance.goToMainMenu();
                ErrorDialog.instance.show(header, context);
            }
            else {
                ApplicationManager.sceneChange += delegate () {
                    ErrorDialog.instance.show(header, context);
                };
                Networking.NetworkingReset();
                ApplicationManager.goToMainMenuScene();
            }
        });
    }




    public void offlineGame(MapEnum mapEnum) {
        LoadingScreen.instance.show("Loading Scene");
        ApplicationManager.goToScene(mapEnum);
    }





    public void createTestMap() {
        LoadingScreen.instance.show("Creating Server");
        sceneName = mapConverter.convert(MapEnum.TEST_MAP);
        socket = Networking.Host((ushort)defaultPort, protocolType, 8);
        socket.TrackBandwidth = true;
        registerSimulationServer();

        registerSocketError();
        registerConnectTimeout();
        registerNetworkReset();
        registerServerDisconnected();
        registerToMasterSever(8, "quick dev server", defaultPort, MapEnum.TEST_MAP);

        registerLoadScene();
    }

    public void joinTestMap() {
        sceneName = mapConverter.convert(MapEnum.TEST_MAP);
        LoadingScreen.instance.show("Joining Server");
        socket = Networking.Connect("127.0.0.1", (ushort)defaultPort, protocolType);
        socket.TrackBandwidth = true;
        registerSimulationClient();

        registerSocketError();
        registerConnectTimeout();
        registerNetworkReset();
        registerServerDisconnected();

        registerLoadScene();
    }

}
