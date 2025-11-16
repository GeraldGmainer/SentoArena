public class SpellBlackFireballHard : SpellBlackFireballBase {

    protected override IObjectPooler getEffectPooler() {
        return BlackFireballHardEffectPooler.instance;
    }

    protected override IObjectPooler getExplosionPooler() {
        return BlackFireballHardExplosionPooler.instance;
    }

    protected override string getReparentPosition() {
        return "BlackFireballPosition";
    }

    protected override IThrowableSpellSettings getSpellSettings() {
        return Settings.instance.blackFireballHard;
    }
}
