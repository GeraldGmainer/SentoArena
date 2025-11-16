using System.Collections.Generic;

public static class SpellList {
    public static List<SpellCombo> combos = new List<SpellCombo>() {
        new BlackFireballCombo1(),
        new BlackFireballCombo2(),
        new BlackFireballCombo3(),
        new BlackFireballTaidenCombo(),
        new BlackFireballAirCombo(),

        new LightningCombo1(),
        new LightningCombo2(),

        new FireballLightningCombo()
    };

    public static SpellCast[] defaultCasts = new SpellCast[] {
        new BlackFireballLightCast1(), new BlackFireballHardCast1(), new BlackFireballPort(),
        new LightningLightCast1(), new LightningHardCast1(), new LightningPort(),

        new BlackFireballChargeCast()
    };

}
