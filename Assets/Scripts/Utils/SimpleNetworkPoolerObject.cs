using BeardedManStudios.Network;

public abstract class SimpleNetworkPoolerObject : SimpleNetworkedMonoBehavior {

    public void Show() {
        RPC_spawn();
        RPC("RPC_spawn", NetworkReceivers.Others);
    }

    [BRPC]
    public void RPC_spawn() {
        getPooler().ShowObject(transform.position, transform.rotation);
    }

    protected abstract INetworkObjectPooler getPooler();
}
