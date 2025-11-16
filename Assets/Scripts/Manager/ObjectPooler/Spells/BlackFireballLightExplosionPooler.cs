
public class BlackFireballLightExplosionPooler : ObjectPooler<BlackFireballLightExplosionPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballLightExplosion";
    }
}
