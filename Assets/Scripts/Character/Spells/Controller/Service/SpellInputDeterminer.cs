using UnityEngine;

public class SpellInputDeterminer {
    private PlayerInputController inputController;

    public SpellInputDeterminer(CharSpellController spellController) {
        inputController = spellController.GetComponent<PlayerInputController>();
    }

    public bool IsAnyFireDown() {
        return
            inputController.GetKeyDown(Keybinding.FIRE1, InputType.SPELL) ||
            inputController.GetKeyDown(Keybinding.FIRE2, InputType.SPELL) ||
            inputController.GetKeyDown(Keybinding.FIRE4, InputType.SPELL);
    }

    public Keybinding determineFireDown() {
        if (inputController.GetKeyDown(Keybinding.FIRE4, InputType.SPELL)) {
            return Keybinding.FIRE4;
        }
        if (inputController.GetKeyDown(Keybinding.FIRE2, InputType.SPELL)) {
            return Keybinding.FIRE2;
        }
        if (inputController.GetKeyDown(Keybinding.FIRE1, InputType.SPELL)) {
            return Keybinding.FIRE1;
        }
        Debug.LogError("wtf combo controller input fail");
        return Keybinding.FIRE1;
    }
}
