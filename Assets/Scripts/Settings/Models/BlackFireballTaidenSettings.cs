using UnityEngine;

[System.Serializable]
public class BlackFireballTaidenSettings : ThrowableSpellSettings, IChargeSettings {
    public BlackFireballTaidenSettings() : base() {
        cooldown = 0f;
        animationDuration = 0.75f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 500f;
        cameraShake = CameraShakeEnum.TAIDEN;
        cameraShakeDelay = 0.4f;
        damage = 100f;
    }

    [SerializeField]
    private float _ChargeTime = 1.5f;
    public float ChargeTime { get { return _ChargeTime; } }

    [SerializeField]
    private float _ChargeTimeDouble = 1f;
    public float ChargeTimeDouble { get { return _ChargeTimeDouble; } }

    [SerializeField]
    private float _SwingAnimationDuration = 0.6f;
    public float SwingAnimationDuration { get { return _SwingAnimationDuration; } }

    [SerializeField]
    private float _SwingAnimationDurationDouble = 1.2f;
    public float SwingAnimationDurationDouble { get { return _SwingAnimationDurationDouble; } }
}
