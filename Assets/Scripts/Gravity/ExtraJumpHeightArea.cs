using UnityEngine;

public class ExtraJumpHeightArea : MonoBehaviour {
    public float jumpMultiplier = 3;

    void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(Vector3.zero, GetComponent<SphereCollider>().radius);
    }
}
