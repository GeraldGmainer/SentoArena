
public class BlackFireballChargedExplosionPooler : ObjectPooler<BlackFireballChargedExplosionPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballChargedExplosion";
    }
}
