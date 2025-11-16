[System.Serializable]
public class LightningPortSettings : SpellSettingsBase {

    public LightningPortSettings() : base() {
        cooldown = 1f;
        animationDuration = 0.5f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
    }
}

