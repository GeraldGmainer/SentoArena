using UnityEngine;

public class PlayerCamera : CharMonoBehaviour {
    public const float START_MOUSE_Y = 10.0f;
    public const float MOUSE_Y_MIN = -89.5f;
    public const float MOUSE_Y_MAX = 89.5f;
    public const float MOUSE_SMOOTH_TIME = 0.08f;
    public const float START_SCROLL = 2.0f;
    public const float SCROLL_SENSITIVITY = 9.9f;
    public const float SCROLL_SMOOTH_TIME = 0.25f;
    public const float MIN_SCROLL_DISTANCE = 1f;
    public const float MAX_SCROLL_DISTANCE = 20.0f;

    public bool updateCamera = true;

    public bool IsThirdPerson { get { return currentCamera == thirdPersonCamera; } }
    public bool IsFirstPerson { get { return currentCamera == firstPersonCamera; } }
    public bool IsLookingBack { get { return currentCamera == lookBackCamera; } }

    private PlayerInputController inputController;
    private PlayerCameraBase currentCamera;
    private PlayerCameraBase lookBackCameraSave;
    private PlayerLookBackCamera lookBackCamera;
    private PlayerFirstPersonCamera firstPersonCamera;
    private PlayerThirdPersonCamera thirdPersonCamera;

    protected override void Awake() {
        base.Awake();
        inputController = GetComponent<PlayerInputController>();
        lookBackCamera = new PlayerLookBackCamera(this);
        firstPersonCamera = new PlayerFirstPersonCamera(this);
        thirdPersonCamera = new PlayerThirdPersonCamera(this);
    }

    protected override void Start() {
        base.Start();
        if (networkController.isNotOwner()) {
            enabled = false;
            return;
        }
        currentCamera = thirdPersonCamera;
    }

    protected override void Update() {
        base.Update();
        if (!updateCamera || currentCamera == null || Time.timeScale == 0) {
            return;
        }

        PlayerCameraBase oldCamera = currentCamera;
        determineNewCurrentCamera();

        if (oldCamera != currentCamera) {
            oldCamera.onLeave();
            currentCamera.onEnter();
        }
    }

    private void determineNewCurrentCamera() {
        if (IsThirdPerson && inputController.GetKeyDown(Keybinding.FIRE3, InputType.CAMERA)) {
            currentCamera = firstPersonCamera;
        }
        else if (IsFirstPerson && inputController.GetKeyDown(Keybinding.FIRE3, InputType.CAMERA)) {
            inputController.CameraInputController.setMouseScrollDesired(inputController.MouseScrollSmooth);
            currentCamera = thirdPersonCamera;
        }
        else if (IsThirdPerson && inputController.MouseScroll > 0 && inputController.CameraInputController.MouseScrollDesired <= MIN_SCROLL_DISTANCE) {
            currentCamera = firstPersonCamera;
        }
        else if (IsFirstPerson && inputController.MouseScroll < 0) {
            inputController.CameraInputController.setMouseScrollDesired(MIN_SCROLL_DISTANCE);
            inputController.CameraInputController.setMouseScrollSmooth(MIN_SCROLL_DISTANCE);
            currentCamera = thirdPersonCamera;
        }
        else if (!IsLookingBack && inputController.GetKeyDown(Keybinding.LOOK_BACK, InputType.CAMERA)) {
            lookBackCameraSave = currentCamera;
            currentCamera = lookBackCamera;
        }
        else if (IsLookingBack && !inputController.GetKey(Keybinding.LOOK_BACK, InputType.CAMERA)) {
            currentCamera = lookBackCameraSave;
        }
    }

    void LateUpdate() {
        if (networkController.isNotOwner()) {
            return;
        }
        if (!updateCamera || Time.timeScale == 0) {
            return;
        }
        currentCamera.update();
    }

    public void portSmoothly() {
        if (IsThirdPerson) {
            thirdPersonCamera.portSmoothly();
        }
    }
}
