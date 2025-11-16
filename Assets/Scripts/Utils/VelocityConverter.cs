using UnityEngine;

public static class VelocityConverter {

    public static float toSpeed(Vector3 velocity) {
        return velocity.magnitude;
    }

    public static float toHorizontalSpeed(Vector3 velocity) {
        return new Vector3(velocity.x, 0, velocity.z).magnitude;
    }

    public static float toVerticalSpeed(Vector3 velocity) {
        return velocity.y;
    }

    public static bool isMoving(Vector3 velocity) {
        return Mathf.Abs(toHorizontalSpeed(velocity)) > 1f;
    }
}
