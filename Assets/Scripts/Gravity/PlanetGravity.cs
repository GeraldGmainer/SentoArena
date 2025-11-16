using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlanetGravity : GravityObject {

    public override Vector3 determineDirection(Vector3 position) {
        return (position - transform.position).normalized;
    }

    void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(Vector3.zero, GetComponent<SphereCollider>().radius);
    }
}
