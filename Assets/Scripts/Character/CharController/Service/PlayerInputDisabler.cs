public class PlayerInputDisabler {
    private PlayerInputController inputController;

    public PlayerInputDisabler(CharController charController) {
        inputController = charController.GetComponent<PlayerInputController>();
    }

    public void SetInputsFromInMenu(bool value) {
        inputController.IsSpellEnabled = value;
        inputController.IsMovementEnabled = value;
        inputController.IsCameraScrollEnabled = value;
        inputController.IsMouseXEnabled = value;
        inputController.IsMouseYEnabled = value;
    }

    public void SetInputsFromChat(bool value) {
        inputController.IsSpellEnabled = value;
        inputController.IsMovementEnabled = value;
        inputController.IsCameraScrollEnabled = value;
        inputController.IsMouseXEnabled = value;
        inputController.IsMouseYEnabled = value;
    }

    public void SetInputsFromPort(bool value) {
        inputController.IsSpellEnabled = value;
        inputController.IsMouseXEnabled = value;
        inputController.IsMovementEnabled = value;
    }

    public void SetInputsFromCharge(bool value) {
        inputController.IsMovementEnabled = value;
    }
}
