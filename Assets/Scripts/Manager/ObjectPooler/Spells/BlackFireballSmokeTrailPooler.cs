public class BlackFireballSmokeTrailPooler : ObjectPooler<BlackFireballSmokeTrailPooler> {
    protected override int getAmount() {
        return 50;
    }

    protected override string getResourcePath() {
        return "Spells/BlackFireball/BlackFireballSmokeTrail";
    }
}
