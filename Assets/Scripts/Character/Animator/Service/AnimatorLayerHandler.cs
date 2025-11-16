using UnityEngine;

public class AnimatorLayerHandler {
    private Animator animator;

    public AnimatorLayerHandler(Animator animator) {
        this.animator = animator;
    }

    public void changeWeapon(IWeaponComponent weaponComponent) {
        animator.SetLayerWeight(AnimatorLayers.HOLD_SWORD_LEFT, weaponComponent.LeftHandAnimationLayerWeight);
        animator.SetLayerWeight(AnimatorLayers.HOLD_SWORD_RIGHT, weaponComponent.RightHandAnimationLayerWeight);
    }

    public void StartCasting(bool isMoving) {
        animator.SetLayerWeight(AnimatorLayers.SPELL_MOVING, isMoving ? 1 : 0);
        animator.SetLayerWeight(AnimatorLayers.SPELL_IDLE, isMoving ? 0 : 1);
    }
}
