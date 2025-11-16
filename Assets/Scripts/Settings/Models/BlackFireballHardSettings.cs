[System.Serializable]
public class BlackFireballHardSettings : ThrowableSpellSettings {

    public BlackFireballHardSettings() : base() {
        animationDuration = 0.95f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 500f;
        cameraShake = CameraShakeEnum.HARD;
        cameraShakeDelay = 0.7f;
        damage = 20f;
    }
}
