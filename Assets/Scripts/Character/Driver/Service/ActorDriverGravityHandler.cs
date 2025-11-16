using UnityEngine;
using System.Collections;
using com.ootii.Actors;

public class ActorDriverGravityHandler {
    private ActorController actorController;
    private CharGravity charGravity;
    private CharActorDriver actorDriver;
    private float currentGravity;

    private float maxSlopeAngleSave;
    private float orientToGroundSpeedSave;

    public ActorDriverGravityHandler(CharActorDriver actorDriver) {
        this.actorDriver = actorDriver;
        actorController = actorDriver.GetComponent<ActorController>();
        charGravity = actorDriver.GetComponentInChildren<CharGravity>();
    }

    public void Start() {
        ResetGravity();
        maxSlopeAngleSave = actorController.MaxSlopeAngle;
        orientToGroundSpeedSave = actorController.OrientToGroundSpeed;
    }

    private void ResetGravity() {
        currentGravity = Settings.instance.charMovement.Gravity;
    }

    public void Update() {
        actorController.Gravity = -Vector3.up * currentGravity * charGravity.gravityDelayMultiplier;
        actorController.IsGravityRelative = charGravity.isGravityRelative();
        actorController.SetTargetGroundNormal(charGravity.gravityDirection);
    }

    public IEnumerator orientToGroundPortPauseTimer() {
        yield return null;
        actorController.enabled = true;
        float startTime = Time.time;

        while (Time.time - startTime < 0.3f) {
            actorController.SetTargetGroundNormal(charGravity.gravityDirection);
            actorController.OrientToGroundSpeed = 0;
            actorController.IsGravityEnabled = false;
            actorController.MaxSlopeAngle = 999;
            yield return null;
        }

        actorController.OrientToGroundSpeed = orientToGroundSpeedSave;
        actorController.IsGravityEnabled = true;
        actorController.MaxSlopeAngle = maxSlopeAngleSave;
    }

    public IEnumerator CustomSpellGravityTimer(ICustomSpellGravity customSpellGravity) {
        float timeUntilFallingDown = Time.time;
        while (VelocityConverter.toVerticalSpeed(actorDriver.Velocity) > 0 && !actorDriver.IsGrounded) {
            timeUntilFallingDown = Time.time;
            yield return null;
        }
        if (customSpellGravity.CustomGravityDuration - (Time.time - timeUntilFallingDown) > 0 && !actorDriver.IsGrounded) {
            currentGravity = customSpellGravity.CustomGravity;
            yield return new WaitForSeconds(customSpellGravity.CustomGravityDuration - (Time.time - timeUntilFallingDown));
            ResetGravity();
        }
    }
}
