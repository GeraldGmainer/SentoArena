using UnityEngine;
using com.ootii.Actors;

public class JumpIdleTest : AnimationTest {
    private ActorController actorController;

    protected override void Awake() {
        base.Awake();
        actorController = GetComponent<ActorController>();
        actorController.Gravity = -Vector3.up * Settings.instance.charMovement.Gravity;
    }

    protected override void Update() {
        base.Update();
        animator.SetBool(AnimatorHashIDs.inAir, !actorController.IsGrounded);
    }

    protected override void TriggerAnimation(int triggerIndex) {
        base.TriggerAnimation(triggerIndex);
        actorController.AddImpulse(transform.up * CalculateJumpForce());
    }

    private float CalculateJumpForce() {
        return Mathf.Sqrt(2 * Settings.instance.charMovement.JumpForce * Settings.instance.charMovement.Gravity);
    }
}
