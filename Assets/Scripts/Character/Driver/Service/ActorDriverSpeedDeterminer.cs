using UnityEngine;

public static class ActorDriverSpeedDeterminer {
    public static float Determine(Vector3 moveDirection, CharMovementSettings charMovement) {
        float resultingSpeed = 0f;
        if (moveDirection.sqrMagnitude > 0f) {
            resultingSpeed = (charMovement.StrafeSpeed * Mathf.Abs(moveDirection.x)
                            + charMovement.RunSpeed * Mathf.Abs(moveDirection.z))
                            / (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        }
        if (moveDirection.z < 0) {
            resultingSpeed *= charMovement.BackwardMultiplier;
        }
        if (Input.GetKey(KeyCode.LeftControl) && Debug.isDebugBuild) {
            resultingSpeed *= 5;
        }
        return resultingSpeed;
    }
}
