using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Network;
using System.Collections;

public class ServerListHandler : MonoBehaviour {
    private const float MAX_TIME_REFRESH_SERVER_LIST = 5f;

    public GameObject serverListPanel;
    public Text serverListInfoText;

    private ServerListSelectionHandler serverListSelectionHandler;

    void Awake() {
        serverListSelectionHandler = GetComponent<ServerListSelectionHandler>();
    }

    public void refresh() {
        GetComponent<CreateJoinMenu>().validatorFindServer.disableJoinButton();
        serverListSelectionHandler.reset();
        clearPanel();
        StopCoroutine("searchingServersInfoTextCoroutine");
        StartCoroutine("searchingServersInfoTextCoroutine");

        MainMenuNetworkManager.instance.getHosts(getHostsCallback);
    }

    private HostInfo createHostInfo(int ping, string serverName, string sceneName, int maxPlayer, int playerCount) {
        HostInfo hostInfo = new HostInfo();
        hostInfo.SetPing(ping);
        hostInfo.name = serverName;
        hostInfo.sceneName = sceneName;
        hostInfo.maxPlayers = maxPlayer;
        hostInfo.connectedPlayers = playerCount;
        return hostInfo;
    }

    private void getHostsCallback(HostInfo[] hostInfos) {
        BeardedManStudios.Network.Unity.MainThreadManager.Run(delegate () {
            clearPanel();
            StopCoroutine("searchingServersInfoTextCoroutine");

            if (hostInfos.Length == 0) {
                setInfoText("No Servers found");
            }
            else {
                fillPanel(hostInfos);
            }
        });
    }


    private void clearPanel() {
        foreach (ServerRow serverRow in serverListPanel.GetComponentsInChildren<ServerRow>()) {
            Destroy(serverRow.gameObject);
        }
    }

    private void fillPanel(HostInfo[] hostInfos) {
        setInfoText(null);
        foreach (HostInfo hostInfo in hostInfos) {
            GameObject go = Instantiate(Resources.Load("UI/ServerList/ServerListRow")) as GameObject;
            setupServerRow(hostInfo, go);
        }
    }

    private void setupServerRow(HostInfo hostInfo, GameObject go) {
        go.transform.SetParent(serverListPanel.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
        ServerRow serverRow = go.GetComponent<ServerRow>();
        serverRow.setup(hostInfo, GetComponent<CreateJoinMenu>().validatorFindServer, () => { serverListSelectionHandler.onClick(serverRow); });
    }

    IEnumerator searchingServersInfoTextCoroutine() {
        float startTime = Time.time;
        while (Time.time - startTime < MAX_TIME_REFRESH_SERVER_LIST) {
            setInfoText("Searching Servers" + getConnectionDots());
            yield return null;
        }
        setInfoText("No Response from MasterServer\nPlease refresh again");
    }

    private string getConnectionDots() {
        string str = "";
        int numberOfDots = Mathf.FloorToInt(Time.timeSinceLevelLoad * 3f % 4);

        for (int i = 0; i < numberOfDots; ++i) {
            str += " .";
        }
        return str;
    }

    private void setInfoText(string text) {
        if (text == null) {
            serverListInfoText.transform.parent.gameObject.SetActive(false);
        }
        else {
            serverListInfoText.transform.parent.gameObject.SetActive(true);
            serverListInfoText.text = text;
        }
    }

}
