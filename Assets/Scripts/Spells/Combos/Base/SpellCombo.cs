public abstract class SpellCombo {
    private SpellCast[] spellAttacks;

    protected SpellCombo() {
        spellAttacks = initSpellAttacks();
    }

    public SpellCast[] getSpellAttacks() {
        return spellAttacks;
    }

    public SpellCast getAttack(int combo) {
        return spellAttacks[combo];
    }

    public int getComboLength() {
        return spellAttacks.Length;
    }

    public abstract string getComboName();
    protected abstract SpellCast[] initSpellAttacks();
}
