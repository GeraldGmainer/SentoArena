using UnityEngine;

[System.Serializable]
public class BlackFireballHardAirSettings : ThrowableSpellSettings, ICustomSpellGravity {
    public BlackFireballHardAirSettings() : base() {
        animationDuration = 0.9f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 500f;
        cameraShake = CameraShakeEnum.HARD_COMBO;
        cameraShakeDelay = 0.7f;
    }

    [SerializeField]
    private float _CustomGravityDuration = 0.8f;
    public float CustomGravityDuration { get { return _CustomGravityDuration; } }

    [SerializeField]
    private float _CustomGravity = 2f;
    public float CustomGravity { get { return _CustomGravity; } }
}
