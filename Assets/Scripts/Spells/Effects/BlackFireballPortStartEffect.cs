public class BlackFireballPortStartEffect : SimpleNetworkPoolerObject {

    protected override INetworkObjectPooler getPooler() {
        return BlackFireballPortStartEffectPooler.instance;
    }
}
