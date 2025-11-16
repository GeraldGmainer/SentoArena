public class BlackFireballPortEndEffect : SimpleNetworkPoolerObject {

    protected override INetworkObjectPooler getPooler() {
        return BlackFireballPortEndEffectPooler.instance;
    }
}
