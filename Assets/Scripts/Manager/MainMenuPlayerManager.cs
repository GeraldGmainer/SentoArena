using UnityEngine;

public class MainMenuPlayerManager : MonoBehaviour {
    public static MainMenuPlayerManager instance;
    private static Vector3 invisiblePosition = new Vector3(100, 100, 100);

    public CharMainMenuController player;

    private Vector3 visiblePosition;

    void Awake() {
        instance = this;
        visiblePosition = player.transform.position;
    }

    public void showPlayer() {
        player.transform.position = visiblePosition;
    }

    public void hidePlayer() {
        player.transform.position = invisiblePosition;
    }

    public void equipWeapon(Weapon weaponEnum) {
        player.ChangeWeapon(weaponEnum);
    }
}
