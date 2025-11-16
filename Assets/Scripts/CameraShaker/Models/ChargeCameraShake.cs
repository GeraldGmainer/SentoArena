using UnityEngine;

public class ChargeCameraShake : CameraShakeBase {
    public ChargeCameraShake() {
        type = Thinksquirrel.CShake.CameraShake.ShakeType.CameraMatrix;
        numberOfShakes = 1;
        shakeAmount = new Vector3(0,0,1f);
        rotationAmount = Vector3.zero;
        distance = 0.9f;
        speed = 35f;
        decay = 0;
        uiShakeModifier = 1f;
        multiplyByTimeScale = true;
    }
}
