public class BlackFireballTaidenCombo : SpellCombo {
    public BlackFireballTaidenCombo() : base() { }

    public override string getComboName() {
        return "Black Fireball Taiden Combo";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballLightCast1(),
            new BlackFireballLightCast2(),
            new BlackFireballHardCast1(),
            new BlackFireballTaidenCast()
        };
    }
}
