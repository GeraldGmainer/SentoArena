using BeardedManStudios.Network;

public abstract class CharNetworkMonoBehaviour : SimpleNetworkedMonoBehavior {
    protected CharAnimator charAnimator;
    protected CharActorDriver actorDriver;
    protected CharController charController;
    protected CharActorDriver charActorDriver;
    protected CharSpellController charSpellController;
    protected CharNetworkController networkController;

    protected virtual void Awake() {
        charAnimator = GetComponent<CharAnimator>();
        actorDriver = GetComponent<CharActorDriver>();
        charController = GetComponent<CharController>();
        charActorDriver = GetComponent<CharActorDriver>();
        charSpellController = GetComponent<CharSpellController>();
        networkController =GetComponent<CharNetworkController>();
    }

    protected virtual void Start() {
    }

    protected virtual void Update() {
    }
}
