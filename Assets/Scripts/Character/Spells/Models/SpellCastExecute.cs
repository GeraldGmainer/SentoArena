public class SpellCastExecute {
    public bool isCombo;
    public SpellCast SpellCast;
    public string comboName;
    public bool isComboCompleted;
    public bool doComboReset;
    public float executeTimestamp;

    public ISpellSettings SpellSettings { get { return SpellCast.SpellSettings; } }
}
