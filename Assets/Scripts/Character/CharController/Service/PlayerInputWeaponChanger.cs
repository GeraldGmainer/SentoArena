public class PlayerInputWeaponChanger {
    private ICharController charController;
    private ICharSpellController spellController;
    private IPlayerInputController inputController;

    public void Update() {
        if (inputController.GetKeyDown(Keybinding.CHANGE_WEAPON, InputType.SPELL)) {
            if (spellController.IsCasting) {
                spellController.RequestWeaponChange(changeWeapon);
            }
            else {
                changeWeapon();
            }
        }
    }

    private void changeWeapon() {
        if (charController.currentWeapon == Weapon.SCYTHE) {
            charController.ChangeWeapon(Weapon.SAI);
        }
        else {
            charController.ChangeWeapon(Weapon.SCYTHE);
        }
    }

    public void SetCharController(ICharController charController) {
        this.charController = charController;
    }

    public void SetCharSpellController(ICharSpellController spellController) {
        this.spellController = spellController;
    }

    public void SetPlayerInputController(IPlayerInputController inputController) {
        this.inputController = inputController;
    }
}
