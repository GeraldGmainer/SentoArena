using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Network;

public class BotManager : MonoBehaviour {
    private const float RESPAWN_TIME = 5f;
    private const string BOT_PATH_ONLINE = "FemaleBot";
    private const string BOT_PATH_OFFLINE = "NetworkResources/Characters/FemaleBot";

    public BotRoute[] BotRoutes;

    private SpawnPointDeterminer spawnPointDeterminer;
    private List<BotController> bots = new List<BotController>();

    public static BotManager instance;

    void Awake() {
        instance = this;
        spawnPointDeterminer = new SpawnPointDeterminer();
    }

    void Start() {
        Invoke("botAdd", 0.2f);
    }

    public void botAdd() {
        botAddOffline();
    }

    public void botKickAll() {
    }

    private void botAddOffline() {
        Transform spawnPoint = spawnPointDeterminer.DetermineForBot();
        GameObject go = Instantiate(Resources.Load(BOT_PATH_OFFLINE), spawnPoint.position, spawnPoint.rotation) as GameObject;
        onSpawnNewBot(go.GetComponent<SimpleNetworkedMonoBehavior>());
    }

    void onSpawnNewBot(SimpleNetworkedMonoBehavior go) {
        go.GetComponent<BotController>().charName = "Bot";
        bots.Add(go.GetComponent<BotController>());
    }


    public void onBotDeath(BotController deadBot) {
        StartCoroutine(respawnTimer(deadBot));
    }

    IEnumerator respawnTimer(BotController deadBot) {
        yield return new WaitForSeconds(RESPAWN_TIME);
        Transform spawnPoint = spawnPointDeterminer.DetermineForBot();
        deadBot.onRespawn(spawnPoint.position, spawnPoint.rotation);
    }

    /*

    private int botIndexCounter = 1;

     public void botAdd() {
        string name = "Bot" + botIndexCounter;
        botIndexCounter++;
        spawnNewBot(name);
    }

    public void botKickAll() {
        foreach (BotController bot in bots) {
            Destroy(bot.gameObject);
        }
        bots = new List<BotController>();
    }


    public void botKickAll() {
        foreach (BotController bot in bots) {
            Destroy(bot.gameObject);
        }
        bots = new List<BotController>();
    }

    public void botDied(BotController deadBot) {
        foreach (BotController bot in bots) {
            if (deadBot == bot) {
                StartCoroutine(respawnTimer(deadBot));
                bots.Remove(deadBot);
                break;
            }
        }
    }

    IEnumerator respawnTimer(BotController deadBot) {
        yield return new WaitForSeconds(5f);
        spawnNewBot(deadBot.character.characterName);
        Destroy(deadBot.ragdoll);
    }

    private void spawnNewBot(string name) {
        Transform spawnPoint = spawnPointDeterminer.determine();
        GameObject bot = Instantiate(Resources.Load(botPrefabPath), spawnPoint.position, spawnPoint.rotation) as GameObject;
        bot.GetComponent<CharacterBase>().character.characterName = name;
        bots.Add(bot.GetComponent<BotController>());
    }
    */
}
