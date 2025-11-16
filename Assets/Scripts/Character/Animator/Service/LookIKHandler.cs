using UnityEngine;

public class LookIKHandler {
    private const float FIRST_PERSON_HEAD_IK_WEIGHT = 1f;
    private const float DAMAGE_SPELL_IK_WEIGHT = 0.1f;
    private const float MAX_CURSOR_HEIGHT = 2.5f;

    private Animator animator;
    private GameObject TPSBone;
    private Camera mainCamera;
    private CharNetworkController networkController;

    public LookIKHandler(CharAnimator charAnimator, Animator animator) {
        this.animator = animator;
        networkController = charAnimator.GetComponent<CharNetworkController>();
        mainCamera = GameObjectFinder.findMainCamera();
        TPSBone = GameObjectFinder.findTPSBone(animator.transform);
    }

    public void onAnimatorIKOwner(bool doFirstPersonHeadIK, bool pauseLookIK) {
        if (pauseLookIK) {
            animator.SetLookAtWeight(0);
        }
        else if (doFirstPersonHeadIK) {
            Vector3 straigtPos = getLookStraightPosition();
            straigtPos.y = networkController.lookAtCursorPosition.y;
            animator.SetLookAtPosition(straigtPos);
            animator.SetLookAtWeight(1, 0.25f, 1, 0);
        }
        else {
            animator.SetLookAtPosition(networkController.lookAtCursorPosition);
            animator.SetLookAtWeight(1, 0.25f, 0, 0);
        }
    }

    public void onAnimatorIKClient() {
        animator.SetLookAtPosition(networkController.lookAtCursorPosition);
        animator.SetLookAtWeight(1, 0.25f, 0, 0);
    }

    public void determineLookAtCursorPosition() {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        float distance = Vector3.Distance(animator.transform.position, mainCamera.transform.position) + 2;
        Vector3 pos = mainCamera.transform.position + ray.direction * distance;
        if (pos.y - animator.transform.position.y > MAX_CURSOR_HEIGHT) {
            pos.y = animator.transform.position.y + MAX_CURSOR_HEIGHT;
        }
        networkController.lookAtCursorPosition = pos;
    }

    private Vector3 getLookStraightPosition() {
        return TPSBone.transform.position + animator.transform.TransformDirection(new Vector3(0, 0, 2f));
    }
}
