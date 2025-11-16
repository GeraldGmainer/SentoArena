[System.Serializable]
public class BlackFireballPortSettings : PortSpellSettings {

    public BlackFireballPortSettings() : base() {
        cooldown = 1f;
        animationDuration = 0.75f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
        maxRange = 15;
        minDistance = 1f;
        portDelay = 0.251f;
        cameraShakeDelay = 0.65f;
        cameraShake = CameraShakeEnum.PORT;
    }
}
