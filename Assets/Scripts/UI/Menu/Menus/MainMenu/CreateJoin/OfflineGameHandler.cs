using UnityEngine;

public class OfflineGameHandler : CreateJoinBase {

    public OfflineGameHandler(CreateJoinMenu createJoinMenu) : base(createJoinMenu) {
    }

    public override void onShow() {
        base.onShow();
        createJoinMenu.headerText.text = "OFFLINE GAME";
        createJoinMenu.enterButtonText.text = "OFFLINE GAME";
        createJoinMenu.tabPanel.showOnlyTabs(2, 3);
        createJoinMenu.enterButton.onClick.RemoveAllListeners();
        createJoinMenu.enterButton.onClick.AddListener(() => onOfflineGame());
    }

    private void onOfflineGame() {
        MapEnum mapEnum = (MapEnum)createJoinMenu.mapSwitcherOfflineGame.getValue();
        MainMenuNetworkManager.instance.offlineGame(mapEnum);
    }

    public void onMapClick() {
        createJoinMenu.mapPreview.changeTo((MapEnum)createJoinMenu.mapSwitcherOfflineGame.getValue());
    }
}
