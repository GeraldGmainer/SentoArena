[System.Serializable]
public class LightningHardSettings : SpellSettingsBase {

    public LightningHardSettings() : base() {
        animationDuration = 1f;
        nextAnimationCanBeFiredAtPercent = 0.3f;
    }
}
