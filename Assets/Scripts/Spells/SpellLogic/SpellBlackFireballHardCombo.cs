public class SpellBlackFireballHardCombo : SpellBlackFireballBase {

    protected override IObjectPooler getEffectPooler() {
        return BlackFireballHardComboEffectPooler.instance;
    }

    protected override IObjectPooler getExplosionPooler() {
        return BlackFireballHardComboExplosionPooler.instance;
    }

    protected override string getReparentPosition() {
        return "BlackFireballPosition";
    }

    protected override IThrowableSpellSettings getSpellSettings() {
        return Settings.instance.blackFireballHardCombo;
    }
}
