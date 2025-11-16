public class PortBlackLinesEffect : SimpleNetworkPoolerObject {

    protected override INetworkObjectPooler getPooler() {
        return PortBlackLinesEffectPooler.instance;
    }
}
