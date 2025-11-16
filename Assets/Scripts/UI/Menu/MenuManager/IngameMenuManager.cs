public class IngameMenuManager : MenuManagerBase {
    public bool isMenuOpen { get; private set; }

    private GameMenu gameMenu;
    private RespawnMenu respawnMenu;
    private ComboListMenu comboListMenu;
    private SettingsMenu settingsMenu;
    private KeybindingsMenu keybindingsMenu;

    public static IngameMenuManager instance;

    void Awake() {
        instance = this;
        gameMenu = GetComponentInChildren<GameMenu>();
        respawnMenu = GetComponentInChildren<RespawnMenu>();
        comboListMenu = GetComponentInChildren<ComboListMenu>();
        settingsMenu = GetComponentInChildren<SettingsMenu>();
        keybindingsMenu = GetComponentInChildren<KeybindingsMenu>();
    }

    public void open() {
        isMenuOpen = true;
    }

    public void close() {
        currentMenu = null;
        isMenuOpen = false;
    }

    public override void onCancel() {
        if (isMenuOpen) {
            currentMenu.onBack();
        }
        else {
            currentMenu = gameMenu;
            currentMenu.onShow();
        }
    }

    public void goToGameMenu() {
        changeMenu(gameMenu);
    }

    public void goToSettings() {
        changeMenu(settingsMenu);
    }

    public void goToComboList() {
        changeMenu(comboListMenu);
    }

    public void goToKeybindings() {
        changeMenu(keybindingsMenu);
    }

    public void showRespawnMenu() {
        changeMenu(respawnMenu);
    }
}
