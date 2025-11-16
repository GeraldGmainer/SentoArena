public class BlackFireballLightEffectPooler : ObjectPooler<BlackFireballLightEffectPooler> {
    protected override int getAmount() {
        return 30;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballLightEffect";
    }
}
