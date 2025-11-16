public class SpellBlackFireballCharge : SpellBlackFireballBase {

    protected override void showBlackFireballEffect() {
        base.showBlackFireballEffect();
        ((BlackFireballChargedEffect)blackFireballEffect).startCharging(0.5f);
    }

    protected override IObjectPooler getEffectPooler() {
        return BlackFireballChargedEffectPooler.instance;
    }

    protected override IObjectPooler getExplosionPooler() {
        return BlackFireballChargedExplosionPooler.instance;
    }

    protected override string getReparentPosition() {
        return "BlackFireballPosition";
    }

    protected override IThrowableSpellSettings getSpellSettings() {
        return Settings.instance.blackFireballCharge;
    }
}
