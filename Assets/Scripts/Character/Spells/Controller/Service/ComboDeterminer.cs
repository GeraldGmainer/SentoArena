using UnityEngine;
using System.Collections.Generic;

public class ComboDeterminer {
    private List<SpellCombo> availableCombos = new List<SpellCombo>();
    private List<SpellCastExecute> emptyHistory = new List<SpellCastExecute>();
    private CharController charController;
    private CharSpellController spellController;
    private CharActorDriver actorDriver;

    public ComboDeterminer(CharSpellController spellController) {
        this.spellController = spellController;
        charController = spellController.GetComponent<CharController>();
        actorDriver = spellController.GetComponent<CharActorDriver>();
    }

    public SpellComboDeterminationResult Determine(Keybinding keybinding, KeybindingType keybindingType) {
        SpellComboDeterminationResult spellComboDeterminationResult = new SpellComboDeterminationResult();
        int currentCombo = spellController.ComboHistory.Length;
        determineAvailableCombos(spellController.ComboHistory.Get, keybinding, keybindingType);
        if (availableCombos.Count == 0) {
            currentCombo = 0;
            spellComboDeterminationResult.doComboReset = true;
            determineAvailableCombos(emptyHistory, keybinding, keybindingType);
        }
        if (availableCombos.Count == 0) {
            return null;
        }
        spellComboDeterminationResult.spellCombo = filterByPriority(currentCombo);
        return spellComboDeterminationResult;
    }

    private void determineAvailableCombos(List<SpellCastExecute> history, Keybinding keybinding, KeybindingType keybindingType) {
        availableCombos = new List<SpellCombo>(SpellList.combos);
        filterCombosByHistory(history);
        filterByCurrentInput(history, keybinding, keybindingType);
    }

    private void filterCombosByHistory(List<SpellCastExecute> history) {
        for (int i = 0; i < history.Count; i++) {
            for (int j = 0; j < SpellList.combos.Count; j++) {
                if (!(isValidComboLength(SpellList.combos[j], i) &&
                        isValidKeybinding(history[i].SpellCast.Keybinding, SpellList.combos[j].getAttack(i)) &&
                        isValidKeybindingType(history[i].SpellCast.KeybindingType, SpellList.combos[j].getAttack(i)) &&
                        isValidInAir(history[i].SpellCast.InAir, SpellList.combos[j].getAttack(i)) &&
                        isValidWeapon(history[i].SpellCast.Weapon, SpellList.combos[j].getAttack(i)))) {

                    availableCombos.Remove(SpellList.combos[j]);
                }
            }
        }
    }

    private void filterByCurrentInput(List<SpellCastExecute> history, Keybinding keybinding, KeybindingType keybindingType) {
        List<SpellCombo> newAvailableCombos = new List<SpellCombo>();
        for (int i = 0; i < availableCombos.Count; i++) {
            if (isValidComboLength(availableCombos[i], history.Count) &&
                    isValidKeybinding(keybinding, availableCombos[i].getAttack(history.Count)) &&
                    isValidKeybindingType(keybindingType, availableCombos[i].getAttack(history.Count)) &&
                    isValidInAir(ConvertIsGrounded(), availableCombos[i].getAttack(history.Count)) &&
                    isValidWeapon(charController.currentWeapon, availableCombos[i].getAttack(history.Count))) {

                newAvailableCombos.Add(availableCombos[i]);
            }
        }
        availableCombos = newAvailableCombos;
    }

    private bool isValidComboLength(SpellCombo spellCombo, int length) {
        return spellCombo.getComboLength() > length;
    }

    private bool isValidKeybinding(Keybinding keybinding, SpellCast spellCast) {
        return keybinding == spellCast.Keybinding;
    }

    private bool isValidKeybindingType(KeybindingType keybindingType, SpellCast spellCast) {
        return keybindingType == spellCast.KeybindingType;
    }

    private bool isValidWeapon(Weapon weapon, SpellCast spellCast) {
        return weapon == spellCast.Weapon;
    }

    private bool isValidInAir(SpellAirEnum inAir, SpellCast spellCast) {
        if (inAir == SpellAirEnum.WAYNE || spellCast.InAir == SpellAirEnum.WAYNE) {
            return true;
        }
        return inAir == spellCast.InAir;
    }

    private SpellAirEnum ConvertIsGrounded() {
        return actorDriver.IsGrounded ? SpellAirEnum.GROUND : SpellAirEnum.AIR;
    }

    private SpellCombo filterByPriority(int currentCombo) {
        SpellCombo spellCombo = availableCombos[0];
        for (int i = 1; i < availableCombos.Count; i++) {
            if (availableCombos[i].getAttack(currentCombo).Priority > spellCombo.getAttack(currentCombo).Priority) {
                spellCombo = availableCombos[i];
            }
        }
        return spellCombo;
    }
}
