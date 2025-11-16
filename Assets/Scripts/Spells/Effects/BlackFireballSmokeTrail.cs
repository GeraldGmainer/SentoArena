using UnityEngine;
using System.Collections;
using ParticlePlayground;

public class BlackFireballSmokeTrail : MonoBehaviour {
    public PlaygroundParticlesC smokeTrail;

    public void start() {
        smokeTrail.emit = false;
    }

    public void startMoving() {
        smokeTrail.emit = true;
    }

    public void releaseSmoke() {
        transform.parent = null;
        smokeTrail.emit = false;
        StopCoroutine("removeSmoke");
        StartCoroutine("removeSmoke");
    }

    IEnumerator removeSmoke() {
        yield return new WaitForSeconds(5f);
        if (BlackFireballSmokeTrailPooler.instance != null) {
            BlackFireballSmokeTrailPooler.instance.disableObject(gameObject);
        }
    }
}
