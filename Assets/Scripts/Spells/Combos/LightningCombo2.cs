public class LightningCombo2 : SpellCombo {
    public LightningCombo2() : base() { }

    public override string getComboName() {
        return "Lightning Combo 2";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new LightningHardCast1(),
            new LightningHardCast1(),
            new LightningHardCast1(),
            new LightningHardCast1()
        };
    }
}
