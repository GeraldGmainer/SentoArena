public class BlackFireballHardEffectPooler : ObjectPooler<BlackFireballHardEffectPooler> {
    protected override int getAmount() {
        return 30;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballHardEffect";
    }
}
