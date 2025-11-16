public class SpellCastDeterminer {
    private CharController charController;
    private CharSpellController spellController;
    private ComboDeterminer comboDeterminer;

    public SpellCastDeterminer(CharSpellController spellController) {
        this.spellController = spellController;
        comboDeterminer = new ComboDeterminer(spellController);
        charController = spellController.GetComponent<CharController>();
    }

    public SpellCastExecute Determine(Keybinding keybinding, KeybindingType keybindingType) {
        SpellComboDeterminationResult spellComboDeterminationResult = comboDeterminer.Determine(keybinding, keybindingType);
        if (spellComboDeterminationResult != null) {
            return prepareComboExecute(spellComboDeterminationResult);
        }
        else {
            return DetermineDefaultExecute(keybinding, keybindingType);
        }
    }

    private SpellCastExecute prepareComboExecute(SpellComboDeterminationResult spellComboDeterminationResult) {
        SpellCastExecute spellCastExecute = new SpellCastExecute();
        int currentCombo = calculateCurrentCombo(spellComboDeterminationResult);

        spellCastExecute.isCombo = true;
        spellCastExecute.doComboReset = spellComboDeterminationResult.doComboReset;
        spellCastExecute.SpellCast = spellComboDeterminationResult.spellCombo.getAttack(currentCombo);
        spellCastExecute.comboName = spellComboDeterminationResult.spellCombo.getComboName();
        if (spellComboDeterminationResult.spellCombo.getComboLength() <= currentCombo + 1) {
            spellCastExecute.isComboCompleted = true;
        }
        return spellCastExecute;
    }

    private int calculateCurrentCombo(SpellComboDeterminationResult spellComboDeterminationResult) {
        if (spellComboDeterminationResult.doComboReset) {
            return 0;
        }
        return spellController.ComboHistory.Length;
    }

    private SpellCastExecute DetermineDefaultExecute(Keybinding keybinding, KeybindingType keybindingType) {
        SpellCastExecute spellCastExecute = new SpellCastExecute();
        spellCastExecute.isCombo = false;
        spellCastExecute.doComboReset = true;
        spellCastExecute.SpellCast = determineDefaultSpellCast(keybinding, keybindingType);
        return spellCastExecute;
    }

    private SpellCast determineDefaultSpellCast(Keybinding keybinding, KeybindingType keybindingType) {
        for (int i = 0; i < SpellList.defaultCasts.Length; i++) {
            if (keybinding == SpellList.defaultCasts[i].Keybinding &&
                keybindingType == SpellList.defaultCasts[i].KeybindingType &&
                charController.currentWeapon == SpellList.defaultCasts[i].Weapon) {
                return SpellList.defaultCasts[i];
            }
        }
        //Debug.Log("no default spell for " + keybinding + " / " + keybindingType + " / " + charController.currentWeapon);
        return null;
    }
}
