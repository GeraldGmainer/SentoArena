using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoxGravity : GravityObject {

    public override Vector3 determineDirection(Vector3 position) {
        return transform.up;
    }

    void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);
    }
}
