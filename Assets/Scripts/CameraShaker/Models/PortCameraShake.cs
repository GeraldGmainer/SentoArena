using UnityEngine;

public class PortCameraShake : CameraShakeBase {
    public PortCameraShake() {
        type = Thinksquirrel.CShake.CameraShake.ShakeType.CameraMatrix;
        numberOfShakes = 1;
        shakeAmount = new Vector3(0, 0, 1f);
        rotationAmount = Vector3.zero;
        distance = 1.5f;
        speed = 30f;
        decay = 0;
        uiShakeModifier = 1f;
        multiplyByTimeScale = true;
    }
}
