using UnityEngine;

public class BlackFireballChargedCurve {
    private AnimationCurve animationCurve;

    public void generate(float chargeTime) {
        animationCurve = new AnimationCurve(generateKeys(chargeTime));
    }

    private Keyframe[] generateKeys(float chargeTime) {
        Keyframe[] keys = new Keyframe[4];
        keys[0] = new Keyframe(0, 0f);
        keys[1] = new Keyframe(0.8f * chargeTime, 0.3f);
        keys[2] = new Keyframe(1f * chargeTime, 1.5f);
        keys[3] = new Keyframe(1.2f * chargeTime, 1f);
        return keys;
    }

    public float getScale(float time) {
        return animationCurve.Evaluate(time);
    }
}
