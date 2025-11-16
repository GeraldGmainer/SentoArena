using UnityEngine;
using UnityEngine.UI;

public class CreateJoinMenu : MenuBase {
    public Text headerText;
    public Button enterButton;
    public WeaponSwitcher weaponSwitcher;
    public MapPreview mapPreview;
    public InputField playerNameField;

    [Header("Create Server")]
    public InputField serverNameField;
    public MapSwitcher mapSwitcherCreateServer;
    public MaxPlayerSwitcher maxPlayerSwitcher;

    [Header("Find Server")]

    [Header("Offline Game")]
    public MapSwitcher mapSwitcherOfflineGame;

    [HideInInspector]
    public TabPanel tabPanel;
    [HideInInspector]
    public Text enterButtonText;

    private CreateServerHandler createServerHandler;
    private FindServerHandler findServerHandler;
    private OfflineGameHandler offlineGameHandler;
    private ValidatorBase currentValidator;
    private ValidatorCreateServer validatorCreateServer;
    public ValidatorFindServer validatorFindServer { get; private set; }
    private ValidatorOfflineGame validatorOfflineGame;

    protected override void Awake() {
        base.Awake();
        tabPanel = GetComponentInChildren<TabPanel>();
        enterButtonText = enterButton.GetComponentInChildren<Text>();

        createServerHandler = new CreateServerHandler(this);
        findServerHandler = new FindServerHandler(this);
        offlineGameHandler = new OfflineGameHandler(this);
        validatorCreateServer = new ValidatorCreateServer(this);
        validatorFindServer = new ValidatorFindServer(this);
        validatorOfflineGame = new ValidatorOfflineGame(this);
    }

    public void showCreateServer() {
        createServerHandler.onShow();
        currentValidator = validatorCreateServer;
        validate();
    }

    public void showFindServer() {
        findServerHandler.onShow();
        currentValidator = validatorFindServer;
        validate();
    }

    public void showOfflineGame() {
        offlineGameHandler.onShow();
        currentValidator = validatorOfflineGame;
        validate();
    }

    public void onMapClickCreateServer() {
        createServerHandler.onMapClick();
    }

    public void onMapClickOfflineGame() {
        offlineGameHandler.onMapClick();
    }

    public void onWeaponClick() {
        MainMenuPlayerManager.instance.equipWeapon((Weapon)weaponSwitcher.getValue());
    }

    public void validate() {
        currentValidator.validate();
    }

    public void onRefresh() {
        findServerHandler.onRefresh();
    }

    public override void onHide() {
        base.onHide();
        mapPreview.hideAll();
    }

    public override void onShow() {
        base.onShow();
        mapPreview.changeTo((MapEnum)Settings.load(SettingsEnum.MAP, (int)MapEnum.PLANET_ARENA));
        MainMenuPlayerManager.instance.showPlayer();
    }

    public override void onBack() {
        base.onBack();
        mainMenuManager.goToMainMenu();
    }
}
