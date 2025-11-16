public class SpellBlackFireballLight : SpellBlackFireballBase {
    protected override IObjectPooler getEffectPooler() {
        return BlackFireballLightEffectPooler.instance;
    }

    protected override IObjectPooler getExplosionPooler() {
        return BlackFireballLightExplosionPooler.instance;
    }

    protected override string getReparentPosition() {
        return "BlackFireballPosition";
    }

    protected override IThrowableSpellSettings getSpellSettings() {
        return Settings.instance.blackFireballLight;
    }
}
