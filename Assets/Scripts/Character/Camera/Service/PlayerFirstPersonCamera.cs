using UnityEngine;

public class PlayerFirstPersonCamera : PlayerCameraBase {
    private Transform TPSBone;
    private CharAnimator charAnimator;
    private CharController charController;

    public PlayerFirstPersonCamera(PlayerCamera playerCamera) : base(playerCamera) {
        TPSBone = GameObjectFinder.findTPSBone(transform).transform;
        charAnimator = playerCamera.GetComponent<CharAnimator>();
        charController = playerCamera.GetComponent<CharController>();
    }

    public override void update() {
        mainCameraTransform.position = TPSBone.position;
        if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.SMOOTHED) {
            mainCameraTransform.rotation = lookAtPositionRespectingRotation(determinePivotPosition(), TPSBone.position);
        }
        else if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.ABSOLUTE) {
            Vector3 rot = mainCameraTransform.rotation.eulerAngles;
            mainCameraTransform.rotation = Quaternion.Euler(rot);
        }
    }

    private Vector3 determinePivotPosition() {
        Quaternion rotXaxis = Quaternion.AngleAxis(inputController.MouseYSmooth, transform.right);
        Quaternion rotYaxis = Quaternion.AngleAxis(0, Vector3.up);
        Quaternion rotation = rotYaxis * rotXaxis;
        return TPSBone.position + rotation * transform.forward;
    }

    public override void onEnter() {
        base.onEnter();
        if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.SMOOTHED) {
            charAnimator.doFirstPersonHeadIK = true;
        }
        else if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.ABSOLUTE) {
            mainCameraTransform.parent = TPSBone;
            mainCameraTransform.localPosition = Vector3.zero;
            mainCameraTransform.localRotation = Quaternion.Euler(0, 280, 270);
        }
        charController.appearanceHandler.hideHair();
    }

    public override void onLeave() {
        base.onLeave();
        if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.SMOOTHED) {
            charAnimator.doFirstPersonHeadIK = false;
        }
        else if (Settings.instance.cameraSettings.FPSCameraMode == FPSCameraMode.ABSOLUTE) {
            mainCameraTransform.parent = null;
        }
        charController.appearanceHandler.showHair();
    }
}
