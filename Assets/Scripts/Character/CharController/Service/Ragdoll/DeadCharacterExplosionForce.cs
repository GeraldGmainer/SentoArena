using UnityEngine;
using BeardedManStudios.Network;

public class DeadCharacterExplosionForce : SimpleNetworkedMonoBehavior {
    private Rigidbody rigidBody;

    void Awake() {
        Transform hips = GameObjectFinder.inChildByName(transform, "hips").transform;
        rigidBody = hips.GetComponent<Rigidbody>();
    }

    public void explode(Vector3 direction) {
        resetPreviousForces();
        if (IsOwner) {
            rigidBody.AddForce(direction * 30000);
        }
    }

    private void resetPreviousForces() {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>()) {
            rb.gameObject.SetActive(false);
            rb.gameObject.SetActive(true);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
