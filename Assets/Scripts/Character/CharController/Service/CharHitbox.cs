using UnityEngine;

public class CharHitbox : MonoBehaviour {

    public CharController CharController;

    private CapsuleCollider characterHitbox;

    void Awake() {
        characterHitbox = GetComponent<CapsuleCollider>();
        if(CharController == null) {
            Debug.LogError("CharHitbox: CharController is null");
        }
    }

    void OnTriggerEnter(Collider collider) {
    }

    public CapsuleCollider getHitbox() {
        return characterHitbox;
    }
}
