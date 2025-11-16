using UnityEngine;

public class BlackFireballEffect : MonoBehaviour {
    private BlackFireballSmokeTrail smokeTrail;

    public virtual void start() {
        smokeTrail = BlackFireballSmokeTrailPooler.instance.retrieveObject().GetComponent<BlackFireballSmokeTrail>();
        smokeTrail.transform.parent = transform;
        smokeTrail.transform.localPosition = Vector3.zero;
        smokeTrail.transform.localRotation = Quaternion.identity;
        smokeTrail.start();
    }

    public virtual void startMoving() {
        smokeTrail.startMoving();
    }

    public virtual void releaseSmoke() {
        smokeTrail.releaseSmoke();
    }
}
