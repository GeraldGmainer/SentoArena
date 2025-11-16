public interface IPlayerInputController {
    bool GetKeyDown(Keybinding keybinding, InputType inputType);

    bool IsSpellEnabled { get; set; }
    bool IsMovementEnabled { get; set; }
    bool IsCameraScrollEnabled { get; set; }
    bool IsMouseXEnabled { get; set; }
    bool IsMouseYEnabled { get; set; }
    CameraInputController CameraInputController { get; }
    float MouseY { get; }
    float MouseScroll { get; }
}
