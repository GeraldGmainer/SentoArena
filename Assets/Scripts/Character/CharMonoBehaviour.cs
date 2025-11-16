using UnityEngine;

public abstract class CharMonoBehaviour : MonoBehaviour {
    protected CharAnimator charAnimator;
    protected CharController charController;
    protected CharActorDriver charActorDriver;
    protected CharSpellController charSpellController;
    protected CharNetworkController networkController;
    protected CharGravity charGravity;

    protected virtual void Awake() {
        charAnimator = GetComponent<CharAnimator>();
        charController = GetComponent<CharController>();
        charActorDriver = GetComponent<CharActorDriver>();
        charSpellController = GetComponent<CharSpellController>();
        networkController = GetComponent<CharNetworkController>();
        charGravity = GetComponentInChildren<CharGravity>();
    }

    protected virtual void Start() {
    }

    protected virtual void Update() {
    }

    protected virtual void OnEnable() {
    }
}
