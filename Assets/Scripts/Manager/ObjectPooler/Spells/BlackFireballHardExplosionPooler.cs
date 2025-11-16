
public class BlackFireballHardExplosionPooler : ObjectPooler<BlackFireballHardExplosionPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballHardExplosion";
    }
}
