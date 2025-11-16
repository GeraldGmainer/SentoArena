using UnityEngine;
using System.Collections;

public class JumpingPuzzleGoal : MonoBehaviour {

    public GameObject[] fireworks;
    public int fireworkIteration = 2;
    public float fireworkGapDelay = 0.5f;
    public float randomGap = 0.3f;
    public float maxRandomX = 3f;
    public float maxRandomY = 3f;
    public float maxRandomZ = 3f;

    private bool hasWon = false;

    public void reset() {
        hasWon = false;
    }

    void OnTriggerEnter(Collider other) {
        if(hasWon) {
            return;
        }
        JumpingPuzzleTimer.instance.stop();
        StartCoroutine("fireworkLoop");
    }

    IEnumerator fireworkLoop() {
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < fireworkIteration; i++) {
            for (int j = 0; j < fireworks.Length; j++) {
                spawnFirework(fireworks[j]);
                yield return new WaitForSeconds(fireworkGapDelay + Random.Range(-randomGap, randomGap));
            }
        }

    }

    private void spawnFirework(GameObject firework) {
        float x = Random.Range(-maxRandomX, maxRandomX);
        float y = Random.Range(0, maxRandomY);
        float z = Random.Range(-maxRandomZ, maxRandomZ);
        Vector3 pos = new Vector3(x, y, z);
        Instantiate(firework, transform.position + pos, Quaternion.identity);
    }
}
