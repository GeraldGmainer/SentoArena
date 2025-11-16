public class BlackFireballChargedEffectPooler : ObjectPooler<BlackFireballChargedEffectPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballChargedEffect";
    }
}
