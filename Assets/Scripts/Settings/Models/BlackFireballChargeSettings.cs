using UnityEngine;

[System.Serializable]
public class BlackFireballChargeSettings : ThrowableSpellSettings, IChargeSettings {
    public BlackFireballChargeSettings() : base() {
        cooldown = 0f;
        animationDuration = 0.75f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        cameraShake = CameraShakeEnum.CHARGE;
        cameraShakeDelay = 0.8f;
        damage = 80f;
        maxRange = 500f;
    }

    [SerializeField]
    private float _ChargeTime = 1f;
    public float ChargeTime { get { return _ChargeTime; } }

    [SerializeField]
    private float _SwingAnimationDuration = 0.3f;
    public float SwingAnimationDuration { get { return _SwingAnimationDuration; } }
}
