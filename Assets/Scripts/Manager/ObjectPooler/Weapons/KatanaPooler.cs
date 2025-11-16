
public class KatanaPooler : ObjectPooler<KatanaPooler> {
    protected override int getAmount() {
        return 16;
    }

    protected override string getResourcePath() {
        return "Weapons/Katana";
    }
}
