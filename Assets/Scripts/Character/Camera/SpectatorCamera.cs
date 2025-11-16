using UnityEngine;

public class SpectatorCamera : MonoBehaviour {
    private const float minimumX = -360F;
    private const float maximumX = 360F;
    private const float minimumY = -60F;
    private const float maximumY = 60F;

    private float verticalAxis;
    private float horizontalAxis;
    private float heightAxis;
    private Vector3 direction;
    private float rotationX;
    private float rotationY;
    private Quaternion originalRotation;

    void Start() {
        if (!Settings.instance.standalone.isStandalone) {
            enabled = false;
        }
        originalRotation = transform.localRotation;
    }

    void Update() {
        handleKeyboardInput();
        if (Input.GetButton(KeybindingsFactory.convert(Keybinding.FIRE1)) || Input.GetButton(KeybindingsFactory.convert(Keybinding.FIRE2))) {
            handleMouseInput();
        }
    }

    private void handleMouseInput() {
        rotationX += Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_X)) * Settings.instance.cameraSettings.MouseSensitivity;
        rotationY += Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_Y)) * Settings.instance.cameraSettings.MouseSensitivity;
        rotationX = clampAngle(rotationX, minimumX, maximumX);
        rotationY = clampAngle(rotationY, minimumY, maximumY);
        Quaternion rot = originalRotation * Quaternion.AngleAxis(rotationX, Vector3.up) * Quaternion.AngleAxis(rotationY, -Vector3.right);
        transform.localRotation = Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, 0);
    }

    private static float clampAngle(float angle, float min, float max) {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    private void handleKeyboardInput() {
        verticalAxis = Input.GetAxisRaw(KeybindingsFactory.convert(Keybinding.VERTICAL));
        horizontalAxis = Input.GetAxisRaw(KeybindingsFactory.convert(Keybinding.HORIZONTAL));
        heightAxis = (Input.GetKey(KeyCode.Q) ? -1 : 0) + (Input.GetKey(KeyCode.E) ? 1 : 0);
        direction = new Vector3(horizontalAxis, heightAxis, verticalAxis);

        transform.Translate(direction * Time.deltaTime * determineSpeed());
    }

    private float determineSpeed() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            return Settings.instance.cameraSettings.SpectatorShiftSpeed;
        }
        return Settings.instance.cameraSettings.SpectatorSpeed;
    }
}
