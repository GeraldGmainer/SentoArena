using UnityEngine;
using BeardedManStudios.Network;

[ScriptOrder(-3)]
public class PlayerManager : MonoBehaviour {
    private const string PLAYER_NETWORK_PATH = "FemalePlayer";
    private const string PLAYER_OFFLINE_PATH = "NetworkResources/Characters/FemalePlayer";

    public bool startWithOpenMenu;
    public PlayerController player { get; private set; }

    private SpawnPointDeterminer spawnPointDeterminer;

    public static PlayerManager instance;

    void Awake() {
        instance = this;
        spawnPointDeterminer = new SpawnPointDeterminer();
    }

    void Start() {
        if (Settings.instance.standalone.isStandalone) {
            return;
        }
        if (!NetworkingManager.IsOnline) {
            Invoke("spawnOfflineCharacter", 0.2f);
        }
        else {
            Invoke("spawnNetworkCharacter", 0.2f);
        }
    }

    private void spawnOfflineCharacter() {
        //System.DateTime time = System.DateTime.Now;
        GameObject go = GameObjectFinder.findPlayer();
        if (go == null) {
            Transform spawnPoint = spawnPointDeterminer.DetermineForPlayer();
            go = Instantiate(Resources.Load(PLAYER_OFFLINE_PATH), spawnPoint.position, spawnPoint.rotation) as GameObject;
        }
        onSpawnCharacter(go.GetComponent<SimpleNetworkedMonoBehavior>());
        //Debug.Log(System.DateTime.Now - time);
    }

    private void spawnNetworkCharacter() {
        Transform spawnPoint = spawnPointDeterminer.DetermineForPlayer();
        Networking.Instantiate(PLAYER_NETWORK_PATH, spawnPoint.position, spawnPoint.rotation, NetworkReceivers.AllBuffered, onSpawnCharacter);
    }

    void onSpawnCharacter(SimpleNetworkedMonoBehavior go) {
        if (go == null) {
            Debug.LogError("wtf onSpawnCharacter null");
        }
        player = go.GetComponent<PlayerController>();
        if (startWithOpenMenu) {
            IngameMenuManager.instance.onCancel();
        }
    }

    public void respawnPlayer() {
        Transform spawnPoint = spawnPointDeterminer.DetermineForPlayer();
        player.onRespawn(spawnPoint.position, spawnPoint.rotation);
    }

    public bool isPlayerDead() {
        return player == null || player.isDead;
    }

    public bool isPlayerCharging() {
        return player.GetComponent<CharSpellController>().IsCharging;
    }
}
