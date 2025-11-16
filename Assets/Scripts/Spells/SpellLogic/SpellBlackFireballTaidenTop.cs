using System;
using UnityEngine;

public class SpellBlackFireballTaidenTop : SpellBlackFireballBase {

    protected override void showBlackFireballEffect() {
        base.showBlackFireballEffect();
        ((BlackFireballChargedEffect)blackFireballEffect).startCharging(0.5f);
    }

    protected override IObjectPooler getEffectPooler() {
        return BlackFireballChargedEffectPooler.instance;
    }

    protected override IObjectPooler getExplosionPooler() {
        return BlackFireballTaidenExplosionPooler.instance;
    }

    protected override string getReparentPosition() {
        return "BlackFireballTaidenPositionTop";
    }

    protected override IThrowableSpellSettings getSpellSettings() {
        return Settings.instance.blackFireballTaiden;
    }
}
