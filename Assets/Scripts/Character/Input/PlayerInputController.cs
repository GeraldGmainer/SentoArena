using UnityEngine;

public class PlayerInputController : CharMonoBehaviour, IPlayerInputController {
    public bool _isXboxController = false;
    public virtual bool isXboxController {
        get { return _isXboxController; }
    }

    public bool IsSpellEnabled { get; set; }
    public bool IsMovementEnabled { get; set; }
    public bool IsCameraScrollEnabled { get; set; }
    public bool IsMouseXEnabled { get; set; }
    public bool IsMouseYEnabled { get; set; }
    public CameraInputController CameraInputController { get; private set; }

    protected override void Awake() {
        base.Awake();
        CameraInputController = new CameraInputController();
        CameraInputController.SetInputController(this);
        CameraInputController.SetMouseSensitivity(Settings.instance.cameraSettings.MouseSensitivity);
    }

    protected override void Start() {
        base.Start();
        if (networkController.isNotOwner()) {
            enabled = false;
            return;
        }
    }

    protected override void OnEnable() {
        base.OnEnable();
        enableAll();
    }

    public void enableAll() {
        IsSpellEnabled = true;
        IsMovementEnabled = true;
        IsCameraScrollEnabled = true;
        IsMouseYEnabled = true;
    }

    protected override void Update() {
        base.Update();
        CameraInputController.Update();
    }


    public float MouseY {
        get {
            return Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_Y));
        }
    }

    public float MouseYSmooth {
        get {
            return CameraInputController.MouseYSmooth;
        }
    }

    public float MouseX {
        get {
            if (!IsMouseXEnabled) {
                return 0f;
            }

            float value = Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_X)) * Settings.instance.cameraSettings.MouseSensitivity;

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
                if (_isXboxController && value == 0f) { value = UnityEngine.Input.GetAxis("MXRightStickX") * (Time.deltaTime / 0.01666f); }
#else
            if (_isXboxController && value == 0f) { value = UnityEngine.Input.GetAxis("WXRightStickX") * (Time.deltaTime / 0.01666f); }
#endif

            return value;
        }
    }

    public float MouseScrollDesired {
        get {
            return CameraInputController.MouseScrollDesired;
        }
    }

    public float MouseScrollSmooth {
        get {
            return CameraInputController.MouseScrollSmooth;
        }
    }

    public float MouseScroll {
        get {
            return Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_SCROLL_WHEEL));
        }
    }


    public float HorizontalAxis {
        get {
            if (!IsMovementEnabled) {
                return 0f;
            }
            return Input.GetAxis(KeybindingsFactory.convert(Keybinding.HORIZONTAL));
        }
    }

    public float VerticalAxis {
        get {
            if (!IsMovementEnabled) {
                return 0f;
            }
            return Input.GetAxis(KeybindingsFactory.convert(Keybinding.VERTICAL));
        }
    }


    public bool GetKeyDown(Keybinding keybinding, InputType inputType) {
        if (!IsInputTypeEnabled(inputType)) {
            return false;
        }
        return Input.GetButtonDown(KeybindingsFactory.convert(keybinding));
    }

    public bool GetKey(Keybinding keybinding, InputType inputType) {
        if (!IsInputTypeEnabled(inputType)) {
            return false;
        }
        return Input.GetButton(KeybindingsFactory.convert(keybinding));
    }

    public bool GetKeyUp(Keybinding keybinding, InputType inputType) {
        if (!IsInputTypeEnabled(inputType)) {
            return false;
        }
        return Input.GetButtonUp(KeybindingsFactory.convert(keybinding));
    }


    private bool IsInputTypeEnabled(InputType inputType) {
        switch (inputType) {
            case InputType.MOVEMENT:
            return IsMovementEnabled;

            case InputType.CAMERA:
            return IsCameraScrollEnabled;

            case InputType.SPELL:
            return IsSpellEnabled;

            default:
            return true;
        }
    }
}
