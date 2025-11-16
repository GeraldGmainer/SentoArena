using UnityEngine;

public class CameraInputController {
    public float MouseYSmooth { get; private set; }
    public float MouseScrollDesired { get; private set; }
    public float MouseScrollSmooth { get; private set; }

    private float mouseSensitivity;
    private float mouseY = PlayerCamera.START_MOUSE_Y;
    private float desiredMouseY = PlayerCamera.START_MOUSE_Y;
    private float mouseYVelocity;
    private float mouseScrollVelocitY;

    private IPlayerInputController inputController;

    public CameraInputController() {
        MouseYSmooth = PlayerCamera.START_MOUSE_Y;
        MouseScrollDesired = PlayerCamera.START_SCROLL;
        MouseScrollSmooth = PlayerCamera.START_SCROLL;
    }

    public void Update() {
        if (inputController.IsMouseYEnabled) {
            determineMouseY();
        }
        if (inputController.IsCameraScrollEnabled) {
            determineScroll();
        }
    }

    private void determineMouseY() {
        desiredMouseY -= inputController.MouseY * mouseSensitivity;
        mouseY = Mathf.Clamp(desiredMouseY, PlayerCamera.MOUSE_Y_MIN, PlayerCamera.MOUSE_Y_MAX);
        desiredMouseY = Mathf.Min(desiredMouseY, PlayerCamera.MOUSE_Y_MAX);
        MouseYSmooth = Mathf.SmoothDamp(MouseYSmooth, mouseY, ref mouseYVelocity, PlayerCamera.MOUSE_SMOOTH_TIME);
    }

    private void determineScroll() {
        MouseScrollDesired = MouseScrollDesired - inputController.MouseScroll * PlayerCamera.SCROLL_SENSITIVITY;
        MouseScrollDesired = Mathf.Clamp(MouseScrollDesired, PlayerCamera.MIN_SCROLL_DISTANCE, PlayerCamera.MAX_SCROLL_DISTANCE);
    }

    public void smoothScroll(float closestDistance) {
        if (closestDistance != -1) {
            if (MouseScrollSmooth < closestDistance) {
                MouseScrollSmooth = Mathf.SmoothDamp(MouseScrollSmooth, closestDistance, ref mouseScrollVelocitY, PlayerCamera.SCROLL_SMOOTH_TIME);
            }
            else {
                MouseScrollSmooth = closestDistance;
            }
        }
        else {
            MouseScrollSmooth = Mathf.SmoothDamp(MouseScrollSmooth, MouseScrollDesired, ref mouseScrollVelocitY, PlayerCamera.SCROLL_SMOOTH_TIME);
        }
    }

    public void setMouseScrollDesired(float value) {
        MouseScrollDesired = value;
    }

    public void setMouseScrollSmooth(float value) {
        MouseScrollSmooth = value;
    }

    public void SetInputController(IPlayerInputController inputController) {
        this.inputController = inputController;
    }

    public void SetMouseSensitivity(float mouseSensitivity) {
        this.mouseSensitivity = mouseSensitivity;
    }
}
