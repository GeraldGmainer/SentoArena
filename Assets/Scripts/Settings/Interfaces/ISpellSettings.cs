public interface ISpellSettings {
    float Cooldown { get; }
    float AnimationDuration { get; }
    float NextAnimationCanBeFiredAtPercent { get; }
    float MaxRange { get; }
    CameraShakeEnum CameraShake { get; }
    float CameraShakeDelay { get; }
}
