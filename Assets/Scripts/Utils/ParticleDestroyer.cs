using System.Collections;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    [SerializeField]
    private float minAliveTime = 1;
    [SerializeField]
    private float maxAliveTime = 10;

    private ParticleSystem ps;

    void Start() {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine("aliveWatcher");
        StartCoroutine("maxAliveTimeTimer");
    }

    IEnumerator aliveWatcher() {
        yield return new WaitForSeconds(minAliveTime);
        while (true) {
            if (ps && !ps.IsAlive()) {
                Destroy(gameObject);
            }
            yield return null;
        }
    }

    IEnumerator maxAliveTimeTimer() {
        yield return new WaitForSeconds(maxAliveTime);
        Destroy(gameObject);
    }
}
