using UnityEngine;
using System.Collections.Generic;

public class CharWeaponEquipper {
    public List<IWeaponComponent> CurrentWeaponComponents = new List<IWeaponComponent>();

    private Transform leftBone;
    private Transform rightBone;

    public CharWeaponEquipper(Transform transform) {
        leftBone = GameObjectFinder.findSwordBoneLeft(transform).transform;
        rightBone = GameObjectFinder.findSwordBoneRight(transform).transform;
    }

    public void Change(Weapon weaponEnum) {
        RemoveOldWeapons();
        EquipNewWeapons(weaponEnum);
    }

    private void EquipNewWeapons(Weapon weaponEnum) {
        IObjectPooler weaponPooler = WeaponFactory.getPooler(weaponEnum);
        WeaponComponentBase weapon = RetrieveWeapon(weaponPooler);

        switch (weapon.WeaponWield) {
            case WeaponWield.LEFT:
            Equip(weapon, leftBone);
            break;

            case WeaponWield.RIGHT:
            Equip(weapon, rightBone);
            break;

            case WeaponWield.DUAL:
            Equip(weapon, leftBone);
            Equip(RetrieveWeapon(weaponPooler), rightBone);
            break;

        }
    }

    private WeaponComponentBase RetrieveWeapon(IObjectPooler weaponPooler) {
        return weaponPooler.retrieveObject().GetComponent<WeaponComponentBase>();
    }

    private void Equip(WeaponComponentBase weapon, Transform bone) {
        weapon.transform.parent = bone;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        CurrentWeaponComponents.Add(weapon);
    }

    private void RemoveOldWeapons() {
        for (int i = 0; i < CurrentWeaponComponents.Count; i++) {
            CurrentWeaponComponents[i].Disable();
        }
        CurrentWeaponComponents.Clear();
    }
}
