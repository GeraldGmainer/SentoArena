using UnityEngine;

public class CreateServerHandler : CreateJoinBase {

    public CreateServerHandler(CreateJoinMenu createJoinMenu) : base(createJoinMenu) {
    }

    public override void onShow() {
        base.onShow();
        createJoinMenu.headerText.text = "CREATE SERVER";
        createJoinMenu.enterButtonText.text = "CREATE SERVER";
        createJoinMenu.tabPanel.showOnlyTabs(0, 3);
        createJoinMenu.enterButton.onClick.RemoveAllListeners();
        createJoinMenu.enterButton.onClick.AddListener(() => onCreateServer());
    }

    private void onCreateServer() {
        int maxPlayer = createJoinMenu.maxPlayerSwitcher.getValue() + 1;
        string serverName = createJoinMenu.serverNameField.text;
        MapEnum mapEnum = (MapEnum)createJoinMenu.mapSwitcherCreateServer.getValue();
        MainMenuNetworkManager.instance.createServer(maxPlayer, serverName, mapEnum);
    }

    public void onMapClick() {
        createJoinMenu.mapPreview.changeTo((MapEnum)createJoinMenu.mapSwitcherCreateServer.getValue());
    }
}
