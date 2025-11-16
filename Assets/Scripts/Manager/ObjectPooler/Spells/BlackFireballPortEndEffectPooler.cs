public class BlackFireballPortEndEffectPooler : NetworkObjectPooler<BlackFireballPortEndEffectPooler> {
    protected override int getAmount() {
        return 10;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballPortEndEffect";
    }
}
