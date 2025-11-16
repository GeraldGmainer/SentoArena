using UnityEngine;
using System.Collections;
using Thinksquirrel.CShake;

public class CameraShaker : MonoBehaviour {
    private static CameraShaker instance;

    private CameraShake cameraShake;
    private CameraShakeFactory cameraShakeFactory;

    public static CameraShaker Instance { get { return instance; } }

    void Awake() {
        instance = this;
        cameraShake = GetComponent<CameraShake>();
        cameraShakeFactory = new CameraShakeFactory();
    }

    public void Shake(CameraShakeEnum cameraShakeNum, float delay) {
        StartCoroutine(ShakeTimer(cameraShakeNum, delay));
    }

    public void Shake(CameraShakeEnum settings) {
        ShakeNow(settings);
    }

    IEnumerator ShakeTimer(CameraShakeEnum cameraShakeNum, float delay) {
        yield return new WaitForSeconds(delay);
        ShakeNow(cameraShakeNum);
    }

    private void ShakeNow(CameraShakeEnum cameraShakeEnum) {
        ICameraShake s = cameraShakeFactory.determine(cameraShakeEnum);
        cameraShake.Shake(s.Type, s.NumberOfShakes, s.ShakeAmount, s.RotationAmount, s.Distance, s.Speed, s.Decay, s.UiShakeModifier, s.MultiplyByTimeScale);
    }
}
