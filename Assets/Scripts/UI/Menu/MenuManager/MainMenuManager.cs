public class MainMenuManager : MenuManagerBase {
    private MainMenu mainMenu;
    private LoadingScreen loadingScreen;
    private CreateJoinMenu createJoinMenu;

    public static MainMenuManager instance;

    void Awake() {
        instance = this;
        mainMenu = GetComponentInChildren<MainMenu>();
        loadingScreen = GetComponentInChildren<LoadingScreen>();
        createJoinMenu = GetComponentInChildren<CreateJoinMenu>();
    }

    void Start() {
        createJoinMenu.onHide();
        loadingScreen.onHide();
        goToMainMenu();
    }

    public void goToMainMenu() {
        changeMenu(mainMenu);
    }

    public void goToCreateServer() {
        changeMenu(createJoinMenu);
        createJoinMenu.showCreateServer();
    }

    public void goToFindServer() {
        changeMenu(createJoinMenu);
        createJoinMenu.showFindServer();
    }

    public void goToLoadingScreen() {
        changeMenu(loadingScreen);
    }

    public void goToOfflineGame() {
        changeMenu(createJoinMenu);
        createJoinMenu.showOfflineGame();
    }

    public void createTest() {
        MainMenuNetworkManager.instance.createTestMap();
    }

    public void joinTest() {
        MainMenuNetworkManager.instance.joinTestMap();
    }
}
