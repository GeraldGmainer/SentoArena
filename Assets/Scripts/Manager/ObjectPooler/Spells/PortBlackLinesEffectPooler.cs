public class PortBlackLinesEffectPooler : NetworkObjectPooler<PortBlackLinesEffectPooler> {
    protected override int getAmount() {
        return 10;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/PortBlackLinesEffect";
    }
}
