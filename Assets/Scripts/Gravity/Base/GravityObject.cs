using UnityEngine;

public abstract class GravityObject : MonoBehaviour {

    public abstract Vector3 determineDirection(Vector3 position);
}
