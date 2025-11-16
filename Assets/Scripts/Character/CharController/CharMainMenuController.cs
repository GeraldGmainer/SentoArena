using UnityEngine;

public class CharMainMenuController : MonoBehaviour, ICharController {
    public CharOutfit outfit;

    public Weapon currentWeapon { get; private set; }
    public IWeaponComponent currentWeaponComponent { get { return weaponEquipper.CurrentWeaponComponents[0]; } }

    private PlayerSettingsLoader charSettingsLoader;
    private CharAppearanceHandler appearanceHandler;
    private CharMainMenuAnimator mainMenuAnimator;
    private CharWeaponEquipper weaponEquipper;

    void Awake() {
        charSettingsLoader = new PlayerSettingsLoader(this);
        appearanceHandler = new CharAppearanceHandler(this);
        weaponEquipper = new CharWeaponEquipper(transform);
        mainMenuAnimator = GetComponent<CharMainMenuAnimator>();
    }

    void Start() {
        charSettingsLoader.load();
        appearanceHandler.Change(outfit);
    }

    public void ChangeWeapon(Weapon weapon) {
        weaponEquipper.Change(weapon);
        mainMenuAnimator.changeWeapon(currentWeaponComponent);
    }

    public void OnDeath(SpellDamage spellDamage) {
    }

    public void OnHealthUpdate() {
    }
}
