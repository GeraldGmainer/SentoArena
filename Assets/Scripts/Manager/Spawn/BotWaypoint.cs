using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BotWaypoint : MonoBehaviour {

    void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, GetComponent<BoxCollider>().size);
    }
}
