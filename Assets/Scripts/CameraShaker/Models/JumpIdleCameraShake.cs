using UnityEngine;

public class JumpIdleCameraShake : CameraShakeBase {
    public JumpIdleCameraShake() {
        type = Thinksquirrel.CShake.CameraShake.ShakeType.LocalPosition;
        numberOfShakes = 1;
        shakeAmount = new Vector3(0, 1, 0f);
        rotationAmount = Vector3.zero;
        distance = 0.1f;
        speed = 30f;
        decay = 0.5f;
        uiShakeModifier = 1f;
        multiplyByTimeScale = true;
    }
}
