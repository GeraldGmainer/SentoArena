
public class BlackFireballTaidenExplosionPooler : ObjectPooler<BlackFireballTaidenExplosionPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballTaidenExplosion";
    }
}
