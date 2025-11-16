using UnityEngine;
using System;
using System.Collections.Generic;

public class SpellSpellStrategyDeterminer {
    private Dictionary<Type, ISpellStrategy> strategies = new Dictionary<Type, ISpellStrategy>();

    private BlackFireballSpellStrategy blackFireball;
    private BlackFireballChargeSpellStrategy blackFireballCharge;
    private BlackFireballTaidenSpellStrategy blackFireballTaiden;
    private BlackFireballPortSpellStrategy blackFireballPort;

    private LightningLightSpellStrategy lightningLight;
    private LightningHardSpellStrategy lightningHard;
    private LightningPortSpellStrategy lightningPort;

    public SpellSpellStrategyDeterminer(CharSpellController spellController) {
        InitStrategies(spellController);
        FillStrategies();
    }

    public ISpellStrategy Determine(SpellCast spellCast) {
        if (!strategies.ContainsKey(spellCast.GetType())) {
            Debug.LogError("CharSpellDeterminer: unknown spellcast");
            return null;
        }
        return strategies[spellCast.GetType()];
    }

    private void InitStrategies(CharSpellController spellController) {
        CharHitbox charHitbox = spellController.GetComponentInChildren<CharHitbox>();
        blackFireball = new BlackFireballSpellStrategy(spellController, charHitbox);
        blackFireballCharge = new BlackFireballChargeSpellStrategy(spellController, charHitbox);
        blackFireballTaiden = new BlackFireballTaidenSpellStrategy(spellController, charHitbox);
        blackFireballPort = new BlackFireballPortSpellStrategy(spellController, charHitbox);

        lightningLight = new LightningLightSpellStrategy(spellController, charHitbox);
        lightningHard = new LightningHardSpellStrategy(spellController, charHitbox);
        lightningPort = new LightningPortSpellStrategy(spellController, charHitbox);

    }

    private void FillStrategies() {
        strategies.Add(typeof(BlackFireballLightCast1), blackFireball);
        strategies.Add(typeof(BlackFireballLightCast2), blackFireball);
        strategies.Add(typeof(BlackFireballLightCast3), blackFireball);
        strategies.Add(typeof(BlackFireballLightCast4), blackFireball);
        strategies.Add(typeof(BlackFireballLightCast5), blackFireball);
        strategies.Add(typeof(BlackFireballHardCast1), blackFireball);
        strategies.Add(typeof(BlackFireballHardCast2), blackFireball);
        strategies.Add(typeof(BlackFireballHardCast3), blackFireball);
        strategies.Add(typeof(BlackFireballHardAirCast), blackFireball);
        strategies.Add(typeof(BlackFireballHardScrewCast), blackFireball);
        strategies.Add(typeof(BlackFireballChargeCast), blackFireballCharge);
        strategies.Add(typeof(BlackFireballTaidenCast), blackFireballTaiden);
        strategies.Add(typeof(BlackFireballPort), blackFireballPort);

        strategies.Add(typeof(LightningLightCast1), lightningLight);
        strategies.Add(typeof(LightningHardCast1), lightningHard);
        strategies.Add(typeof(LightningPort), lightningPort);
    }
}
