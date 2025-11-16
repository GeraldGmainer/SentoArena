using UnityEngine;

public class PlayerThirdPersonCamera : PlayerCameraBase {
    private const float PORT_LERP_SPEED = 0.4f;
    private PlayerCameraViewFrustum cameraViewFrustum;
    private PlayerCameraPivotDeterminer pivotDeterminer;

    private float portLerp = 1;
    private Quaternion startRotation;
    private Vector3 cameraPivotPosition;

    public PlayerThirdPersonCamera(PlayerCamera playerCamera) : base(playerCamera) {
        cameraViewFrustum = new PlayerCameraViewFrustum();
        pivotDeterminer = new PlayerCameraPivotDeterminer(playerCamera);
    }

    public override void update() {
        cameraPivotPosition = pivotDeterminer.determine(inputController.MouseScrollSmooth);

        Vector3 desiredPosition = calculateCameraPosition(inputController.MouseYSmooth, 0, inputController.MouseScrollDesired);
        float closestDistance = determineClosestDistance(desiredPosition);

        inputController.CameraInputController.smoothScroll(closestDistance);

        desiredPosition = calculateCameraPosition(inputController.MouseYSmooth, 0, inputController.MouseScrollSmooth);
        if (portLerp >= 1) {
            mainCameraTransform.position = desiredPosition;
        }

        Quaternion desiredRotation = lookAtPositionRespectingRotation(cameraPivotPosition, desiredPosition);
        mainCameraTransform.rotation = Quaternion.Lerp(startRotation, desiredRotation, portLerp);

        portLerp = Mathf.Clamp01(portLerp + Time.deltaTime / PORT_LERP_SPEED);
    }

    private float determineClosestDistance(Vector3 desiredPosition) {
        float closestDistance = cameraViewFrustum.checkForOccultation(desiredPosition, cameraPivotPosition, mainCamera);
        if (closestDistance != -1) {
            closestDistance -= mainCamera.nearClipPlane;
        }
        return closestDistance;
    }

    private Vector3 calculateCameraPosition(float xAxisDegrees, float yAxisDegrees, float distance) {
        Quaternion rotXaxis = Quaternion.AngleAxis(xAxisDegrees, transform.right);
        Quaternion rotYaxis = Quaternion.AngleAxis(0, transform.up);
        return cameraPivotPosition + (rotYaxis * rotXaxis * -transform.forward * distance);
    }

    public void portSmoothly() {
        startRotation = mainCameraTransform.rotation;
        portLerp = 0;

        cameraPivotPosition = pivotDeterminer.determine(inputController.MouseScrollSmooth);
        Vector3 desiredPosition = calculateCameraPosition(inputController.MouseYSmooth, 0, inputController.MouseScrollDesired);
        iTween.MoveTo(mainCamera.gameObject, iTween.Hash("position", desiredPosition, "easeType", iTween.EaseType.easeInOutExpo, "time", PORT_LERP_SPEED));
    }
}
