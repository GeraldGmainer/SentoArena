public class BlackFireballPortStartEffectPooler : NetworkObjectPooler<BlackFireballPortStartEffectPooler> {
    protected override int getAmount() {
        return 10;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballPortStartEffect";
    }
}
