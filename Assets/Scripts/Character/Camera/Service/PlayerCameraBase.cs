using UnityEngine;

public abstract class PlayerCameraBase {
    protected Transform mainCameraTransform;
    protected Camera mainCamera;
    protected PlayerCamera playerCamera;
    protected Transform transform;
    protected PlayerInputController inputController;

    protected PlayerCameraBase(PlayerCamera playerCamera) {
        this.playerCamera = playerCamera;
        inputController = playerCamera.GetComponent<PlayerInputController>();
        transform = playerCamera.transform;
        mainCamera = GameObjectFinder.findMainCamera();
        mainCameraTransform = mainCamera.transform;
    }

    protected Quaternion lookAtPositionRespectingRotation(Vector3 target, Vector3 start) {
        return Quaternion.LookRotation(target - start, transform.up);
    }

    public virtual void onEnter() {

    }

    public virtual void onLeave() {

    }

    public abstract void update();
}
