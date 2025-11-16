public class BlackFireballAirCombo : SpellCombo {
    public BlackFireballAirCombo() : base() { }

    public override string getComboName() {
        return "Black Fireball Air Combo 3";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballLightCast1(),
            new BlackFireballLightCast2(),
            new BlackFireballHardAirCast()
        };
    }
}
