using UnityEngine;

public class PlayerLookBackCamera : PlayerCameraBase {
    private static Vector3 LOOK_AT_POSITION = new Vector3(0, 1.5f, 0);
    private static Vector3 CAMERA_LOCAL_POSITION = new Vector3(0, 1.7f, 2f);

    private CharAnimator charAnimator;

    public PlayerLookBackCamera(PlayerCamera playerCamera) : base(playerCamera) {
        charAnimator = playerCamera.GetComponent<CharAnimator>();
    }

    public override void update() {
        Vector3 desiredPosition = transform.position + transform.TransformDirection(CAMERA_LOCAL_POSITION);
        Vector3 lookPosition = transform.position + transform.TransformDirection(LOOK_AT_POSITION);
        mainCameraTransform.position = desiredPosition;
        mainCameraTransform.rotation = lookAtPositionRespectingRotation(lookPosition, desiredPosition);
    }

    public override void onEnter() {
        HUD.instance.hideCrosshair();
        charAnimator.PauseLookIK = true;
    }

    public override void onLeave() {
        HUD.instance.showCrosshair();
        charAnimator.PauseLookIK = false;
    }

}
