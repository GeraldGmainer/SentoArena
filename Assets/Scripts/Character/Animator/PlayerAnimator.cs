using UnityEngine;

public class PlayerAnimator : CharAnimator {
    private PlayerCamera playerCamera;

    protected override void Awake() {
        base.Awake();
        playerCamera = GetComponent<PlayerCamera>();
    }

    protected override void OnAnimatorIK() {
        base.OnAnimatorIK();
        if (Time.timeScale == 0 || !playerCamera.updateCamera) {
            return;
        }
        if (networkController.isOwner()) {
            lookIKHandler.determineLookAtCursorPosition();
            lookIKHandler.onAnimatorIKOwner(doFirstPersonHeadIK, PauseLookIK);
        }
        else {
            lookIKHandler.onAnimatorIKClient();
        }
    }
}
