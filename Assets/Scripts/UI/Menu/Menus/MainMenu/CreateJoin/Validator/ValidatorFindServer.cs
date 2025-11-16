using UnityEngine;

public class ValidatorFindServer : ValidatorBase {
    private ServerListSelectionHandler serverListSelectionHandler;

    public ValidatorFindServer(CreateJoinMenu createJoinMenu) : base(createJoinMenu) {
        serverListSelectionHandler = createJoinMenu.GetComponent<ServerListSelectionHandler>();
    }

    public override void validate() {
        isValid = isAnyServerSelected() && isPlayerNameFilled();
        createJoinMenu.enterButton.interactable = isValid;
    }

    private bool isAnyServerSelected() {
        return serverListSelectionHandler.isAnyServerSelected();
    }

    private bool isPlayerNameFilled() {
        return createJoinMenu.playerNameField.text != null && createJoinMenu.playerNameField.text.Length > 0;
    }

    public void disableJoinButton() {
        isValid = false;
        createJoinMenu.enterButton.interactable = false;
    }
}
