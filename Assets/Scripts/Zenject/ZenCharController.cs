using UnityEngine;
using Zenject;

public class ZenCharController : MonoBehaviour {
    public Weapon m_weapon;
    public CharOutfit m_charOutfit;

    [Inject]
    private ZenWeaponEquipper m_weaponEquipper;

	void Start() {
        m_weaponEquipper.Equip(m_weapon);
    }
	
}
