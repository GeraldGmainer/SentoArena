public class BlackFireballCombo1 : SpellCombo {
    public BlackFireballCombo1() : base() { }

    public override string getComboName() {
        return "Black Fireball Combo 1";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballLightCast1(),
            new BlackFireballLightCast2(),
            new BlackFireballLightCast3(),
            new BlackFireballLightCast4(),
            new BlackFireballLightCast5()
        };
    }
}
