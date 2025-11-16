using System;
using System.Collections.Generic;

public class WeaponSwitcher : SettingSwitcher {
    public override string[] getUIList() {
        return convertNames();
    }

    private static string[] convertNames() {
        List<string> names = new List<string>();

        foreach (Weapon weapon in Enum.GetValues(typeof(Weapon))) {

            switch (weapon) {

                case Weapon.SCYTHE:
                names.Add("Scythe");
                break;

                case Weapon.SAI:
                names.Add("Sai");
                break;

                case Weapon.KATANA:
                names.Add("Katana");
                break;

                default:
                names.Add("WTF");
                break;

            }
        }
        return names.ToArray();
    }
}
