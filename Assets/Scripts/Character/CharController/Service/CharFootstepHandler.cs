using UnityEngine;

public class CharFootstepHandler {
    private Transform transform;

    private static Vector3 LEFT_OFFSET = new Vector3(-0.1f, 0, 0.2f);
    private static Vector3 RIGHT_OFFSET = new Vector3(0.1f, 0, 0.2f);

    private CharActorDriver actorDriver;
    private CharController charController;
    private CharNetworkController networkController;

    public CharFootstepHandler(CharController charController) {
        this.charController = charController;
        transform = charController.transform;
        networkController = charController.GetComponent<CharNetworkController>();
        actorDriver = charController.GetComponent<CharActorDriver>();
    }

    public void SpawnLeftFootstepAnimationEvent(string animationType) {
        spawn(LEFT_OFFSET, animationType);
    }

    public void SpawnRightFootstepAnimationEvent(string animationType) {
        spawn(RIGHT_OFFSET, animationType);
    }

    private void spawn(Vector3 offset, string animationType) {
        if (Mathf.Abs(VelocityConverter.toHorizontalSpeed(actorDriver.Velocity)) < 3) {
            return;
        }
        if (preventOldEventFromStrafingRun(animationType)) {
            return;
        }
        if (preventOldEventFromNormalRun(animationType)) {
            return;
        }
        RetrieveParticle(transform.position + transform.TransformDirection(offset), transform.rotation);
    }
    private GameObject RetrieveParticle(Vector3 pos, Quaternion rot) {
        return charController.currentWeaponComponent.FootstepPooler.retrieveObject(pos, rot);
    }

    private bool preventOldEventFromNormalRun(string animationType) {
        //because of blend tree
        return !"strafing".Equals(animationType) && Mathf.Abs(networkController.strafe) > 0.4f;
    }

    private bool preventOldEventFromStrafingRun(string animationType) {
        return "strafing".Equals(animationType) && Mathf.Abs(networkController.strafe) < 0.2f;
    }

}
