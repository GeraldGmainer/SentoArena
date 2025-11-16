using UnityEngine.UI;

public class SettingsMenu : MenuBase {
    public Slider mouseSensitivity;

    public void updateMouseSensitivity(float value) {
        Settings.instance.cameraSettings.MouseSensitivity = value;
    }

    public override void onBack() {
        base.onBack();
        ingameMenuManager.goToGameMenu();
    }
}
