
public class BlackFireballHardComboExplosionPooler : ObjectPooler<BlackFireballHardComboExplosionPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballHardComboExplosion";
    }
}
