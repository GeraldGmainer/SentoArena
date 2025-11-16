using UnityEngine;

[System.Serializable]
public class BlackFireballHardComboSettings : ThrowableSpellSettings, ICustomSpellGravity {
    public BlackFireballHardComboSettings() : base() {
        animationDuration = 0.9f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 500f;
        cameraShake = CameraShakeEnum.HARD_COMBO;
        cameraShakeDelay = 0.7f;
        damage = 50f;
    }

    [SerializeField]
    private float _CustomGravityDuration = 0.8f;
    public float CustomGravityDuration { get { return _CustomGravityDuration; } }

    [SerializeField]
    private float _CustomGravity = 0.1f;
    public float CustomGravity { get { return _CustomGravity; } }
}
