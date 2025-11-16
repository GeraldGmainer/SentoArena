public class BlackFireballCombo3 : SpellCombo {
    public BlackFireballCombo3() : base() { }

    public override string getComboName() {
        return "Black Fireball Combo 3";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballLightCast1(),
            new BlackFireballLightCast2(),
            new BlackFireballLightCast1(),
            new BlackFireballHardScrewCast()
        };
    }
}
