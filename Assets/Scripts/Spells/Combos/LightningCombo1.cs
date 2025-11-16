public class LightningCombo1 : SpellCombo {
    public LightningCombo1() : base() { }

    public override string getComboName() {
        return "Lightning Combo 1";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new LightningLightCast1(),
            new LightningLightCast1(),
            new LightningLightCast1(),
            new LightningLightCast1()
        };
    }
}
