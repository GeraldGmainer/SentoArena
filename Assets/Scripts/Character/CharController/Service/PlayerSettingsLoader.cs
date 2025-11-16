using UnityEngine;

public class PlayerSettingsLoader {
    private ICharController charController;

    public PlayerSettingsLoader(ICharController charController) {
        this.charController = charController;
    }

    public void load() {
        charController.ChangeWeapon((Weapon)Settings.load(SettingsEnum.WEAPON, (int)Weapon.SCYTHE));
    }
}
