using UnityEngine;

public class HardComboCameraShake : CameraShakeBase {
    public HardComboCameraShake() {
        type = Thinksquirrel.CShake.CameraShake.ShakeType.CameraMatrix;
        numberOfShakes = 1;
        shakeAmount = new Vector3(0, 0.2f, 1f);
        rotationAmount = Vector3.zero;
        distance = 2.5f;
        speed = 35f;
        decay = 0;
        uiShakeModifier = 1f;
        multiplyByTimeScale = true;
    }
}
