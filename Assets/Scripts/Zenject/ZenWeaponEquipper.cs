using UnityEngine;
using Zenject;

public class ZenWeaponEquipper {

    [Inject]
    private ZenBoneService m_boneService;

    [Inject]
    public void Construct() {
        Debug.Log(m_boneService.RightSwordBone.name);
    }

    public void Equip(Weapon weapon) {
        Debug.Log(m_boneService.LeftSwordBone.name);
    }
}
