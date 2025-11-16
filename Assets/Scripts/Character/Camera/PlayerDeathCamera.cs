using UnityEngine;
using BeardedManStudios.Network;

public class PlayerDeathCamera : SimpleNetworkedMonoBehavior {
    private static float START_SCROLL = 5f;
    private static float START_MOUSE_X = 0;
    private static float START_MOUSE_Y = 15.0f;

    private Camera mainCamera;
    private Vector3 cameraPivotPosition;

    void Awake() {
        mainCamera = GameObjectFinder.findMainCamera();
    }

    protected override void NetworkStart() {
        base.NetworkStart();
        if (!IsOwner) {
            enabled = false;
        }
    }

    void LateUpdate() {
        updatePivotPosition();
        updateCameraPosition(determineNewCameraPosition());
    }

    private void updatePivotPosition() {
        cameraPivotPosition = GameObjectFinder.inChildByName(transform, "chest").transform.position;
        cameraPivotPosition += new Vector3(0, 2, 0);
    }

    private void updateCameraPosition(Vector3 newCameraPosition) {
        mainCamera.transform.position = newCameraPosition;
        mainCamera.transform.LookAt(cameraPivotPosition);
    }

    private Vector3 determineNewCameraPosition() {
        Vector3 offset = -transform.forward;
        offset.y = 0.0f;
        offset *= START_SCROLL;

        Quaternion rotXaxis = Quaternion.AngleAxis(START_MOUSE_X, transform.right);
        Quaternion rotYaxis = Quaternion.AngleAxis(START_MOUSE_Y, Vector3.up);
        Quaternion rotation = rotYaxis * rotXaxis;

        return cameraPivotPosition + rotation * offset;
    }

}
