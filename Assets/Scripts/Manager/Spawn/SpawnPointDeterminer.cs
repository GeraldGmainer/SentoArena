using UnityEngine;
using System.Collections.Generic;

public class SpawnPointDeterminer {
    private List<Transform> playerSpawnPoints = new List<Transform>();
    private List<Transform> botSpawnPoints = new List<Transform>();

    public SpawnPointDeterminer() {
        FindPlayerSpawnPoints();
        FindBotSpawnPoints();
    }

    private void FindPlayerSpawnPoints() {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Tags.PlayerRespawn)) {
            playerSpawnPoints.Add(go.transform);
        }
    }

    private void FindBotSpawnPoints() {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Tags.BotRespawn)) {
            botSpawnPoints.Add(go.transform);
        }
    }


    public Transform DetermineForPlayer() {
        return Determine(playerSpawnPoints);
    }

    public Transform DetermineForBot() {
        return Determine(botSpawnPoints);
    }

    private Transform Determine(List<Transform> spawnPoints) {
        List<Transform> emptySpawnPoints = DetermineEmptySpawnPoints(spawnPoints);
        if (emptySpawnPoints.Count == 0) {
            return DetermineSpawn(spawnPoints);
        }
        return DetermineSpawn(emptySpawnPoints);
    }

    private List<Transform> DetermineEmptySpawnPoints(List<Transform> spawnPoints) {
        List<Transform> emptySpawnPoints = new List<Transform>();
        foreach (Transform trans in spawnPoints) {
            if (trans.GetComponent<SpawnPoint>().isEmpty()) {
                emptySpawnPoints.Add(trans);
            }
        }
        return emptySpawnPoints;
    }

    private Transform DetermineSpawn(List<Transform> spawnPoints) {
        int random = Random.Range(0, spawnPoints.Count);
        return spawnPoints[random].transform;
    }
}
