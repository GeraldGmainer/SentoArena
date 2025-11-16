using UnityEngine;

public class HardCameraShake : CameraShakeBase {
    public HardCameraShake() {
        type = Thinksquirrel.CShake.CameraShake.ShakeType.CameraMatrix;
        numberOfShakes = 1;
        shakeAmount = new Vector3(0, 0, 1f);
        rotationAmount = Vector3.zero;
        distance = 1.5f;
        speed = 35f;
        decay = 0;
        uiShakeModifier = 1f;
        multiplyByTimeScale = true;
    }
}
