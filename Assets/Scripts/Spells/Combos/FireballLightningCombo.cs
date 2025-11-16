public class FireballLightningCombo : SpellCombo {
    public FireballLightningCombo() : base() { }

    public override string getComboName() {
        return "Fireball Lightning Combo";
    }

    protected override SpellCast[] initSpellAttacks() {
        return new SpellCast[] {
            new BlackFireballLightCast1(),
            new BlackFireballHardCast1(),
            new LightningLightCast1()
        };
    }
}
