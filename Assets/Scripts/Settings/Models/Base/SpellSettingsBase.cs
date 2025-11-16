using UnityEngine;

public abstract class SpellSettingsBase : ISpellSettings {
    [SerializeField]
    protected float cooldown;
    [SerializeField]
    protected float animationDuration;
    [SerializeField]
    [Range(0, 1)]
    protected float nextAnimationCanBeFiredAtPercent;
    [SerializeField]
    protected CameraShakeEnum cameraShake;
    [SerializeField]
    protected float cameraShakeDelay;
    [SerializeField]
    protected float maxRange;

    protected SpellSettingsBase() {
    }

    public float Cooldown { get { return cooldown; } }
    public float AnimationDuration { get { return animationDuration; } }
    public float NextAnimationCanBeFiredAtPercent { get { return nextAnimationCanBeFiredAtPercent; } }
    public float MaxRange { get { return maxRange; } }
    public CameraShakeEnum CameraShake { get { return cameraShake; } }
    public float CameraShakeDelay { get { return cameraShakeDelay; } }
}
