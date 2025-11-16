using UnityEngine;

public class PlayerCameraPivotDeterminer {
    private const float HEIGHT_TO_HEAD = 1.5f;

    private AnimationCurve pivotYCurve;
    private AnimationCurve pivotZCurve;

    private Transform transform;

    public PlayerCameraPivotDeterminer(PlayerCamera playerCamera) {
        transform = playerCamera.transform;
        pivotYCurve = new AnimationCurve(generateYKeys());
        pivotZCurve = new AnimationCurve(generateZKeys());
    }

    public Vector3 determine(float mouseScrollSmooth) {
        return transform.position + transform.TransformVector(new Vector3(0, getPivotY(mouseScrollSmooth), getPivotZ(mouseScrollSmooth)));
    }


    private Keyframe[] generateYKeys() {
        Keyframe[] keys = new Keyframe[3];
        keys[0] = new Keyframe(0, HEIGHT_TO_HEAD);
        keys[1] = new Keyframe(2, HEIGHT_TO_HEAD + 0.2f);
        keys[1].inTangent = 0.5f;
        keys[1].outTangent = 0.5f;
        keys[2] = new Keyframe(15, HEIGHT_TO_HEAD + 3f);
        return keys;
    }

    private Keyframe[] generateZKeys() {
        Keyframe[] keys = new Keyframe[2];
        keys[0] = new Keyframe(0, 0.15f);
        keys[1] = new Keyframe(1, 0);
        return keys;
    }

    private float getPivotY(float time) {
        return pivotYCurve.Evaluate(time);
    }

    private float getPivotZ(float time) {
        return pivotZCurve.Evaluate(time);
    }

}
