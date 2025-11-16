using UnityEngine;

public class CharMainMenuAnimator : MonoBehaviour {
    private Animator animator;
    private AnimatorLayerHandler layerHandler;

    void Awake () {
        animator = GetComponent<Animator>();
        layerHandler = new AnimatorLayerHandler(animator);
    }
	
	void Update () {
        animator.SetFloat(AnimatorHashIDs.horizontalSpeed, 0, 10, CharAnimator.TRANSITION_DAMP * Time.deltaTime);
        animator.SetFloat(AnimatorHashIDs.direction, 0, 20, CharAnimator.TRANSITION_DAMP * Time.deltaTime);
        animator.SetFloat(AnimatorHashIDs.strafe, 0, 5, CharAnimator.TRANSITION_DAMP * Time.deltaTime);
        animator.SetBool(AnimatorHashIDs.isMoving, false);
        animator.SetBool(AnimatorHashIDs.inAir, false);
    }

    public void changeWeapon(IWeaponComponent weaponComponent) {
        layerHandler.changeWeapon(weaponComponent);
    }
}
