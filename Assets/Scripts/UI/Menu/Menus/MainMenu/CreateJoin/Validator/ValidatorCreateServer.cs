
public class ValidatorCreateServer : ValidatorBase {
    public ValidatorCreateServer(CreateJoinMenu createJoinMenu) : base(createJoinMenu) {
    }

    public override void validate() {
        isValid = isServerNameFilled() && isPlayerNameFilled();
        createJoinMenu.enterButton.interactable = isValid;
    }

    private bool isServerNameFilled() {
        return createJoinMenu.serverNameField.text != null && createJoinMenu.serverNameField.text.Length > 0;
    }

    private bool isPlayerNameFilled() {
        return createJoinMenu.playerNameField.text != null && createJoinMenu.playerNameField.text.Length > 0;
    }
}
