public class BlackFireballCombo2 : SpellCombo {
    public BlackFireballCombo2() : base() { }

    public override string getComboName() {
        return "Black Fireball Combo 2";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballHardCast1(),
            new BlackFireballHardCast2(),
            new BlackFireballHardCast1(),
            new BlackFireballHardCast2(),
            new BlackFireballHardCast3()
        };
    }
}
