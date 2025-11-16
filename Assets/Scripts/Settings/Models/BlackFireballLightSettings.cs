[System.Serializable]
public class BlackFireballLightSettings : ThrowableSpellSettings {

    public BlackFireballLightSettings() : base() {
        animationDuration = 0.5f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 500f;
        cameraShake = CameraShakeEnum.NONE;
        damage = 10f;
    }
}
