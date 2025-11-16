public class BlackFireballHardComboEffectPooler : ObjectPooler<BlackFireballHardComboEffectPooler> {
    protected override int getAmount() {
        return 30;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballHardComboEffect";
    }
}
