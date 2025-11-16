public class SaiPooler : ObjectPooler<SaiPooler> {
    protected override int getAmount() {
        return 32;
    }

    protected override string getResourcePath() {
        return "Weapons/Sai";
    }
}
