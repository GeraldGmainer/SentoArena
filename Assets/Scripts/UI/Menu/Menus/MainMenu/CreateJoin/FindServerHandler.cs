using UnityEngine;

public class FindServerHandler : CreateJoinBase {
    private ServerListHandler serverListHandler;
    private ServerListSelectionHandler serverListSelectionHandler;

    public FindServerHandler(CreateJoinMenu createJoinMenu) : base(createJoinMenu) {
        serverListHandler = createJoinMenu.GetComponent<ServerListHandler>();
        serverListSelectionHandler = createJoinMenu.GetComponent<ServerListSelectionHandler>();
    }

    public override void onShow() {
        base.onShow();
        createJoinMenu.headerText.text = "FIND SERVER";
        createJoinMenu.enterButtonText.text = "JOIN SERVER";
        createJoinMenu.tabPanel.showOnlyTabs(1, 3);
        createJoinMenu.enterButton.onClick.RemoveAllListeners();
        createJoinMenu.enterButton.onClick.AddListener(() => onJoinServer());
        onRefresh();
    }

    private void onJoinServer() {
        MainMenuNetworkManager.instance.joinServer(serverListSelectionHandler.getSelectedHostInfo());
    }

    public void onRefresh() {
        serverListHandler.refresh();
        createJoinMenu.mapPreview.showDefault();
    }
}
