
public class ScythePooler : ObjectPooler<ScythePooler> {
    protected override int getAmount() {
        return 20;
    }

    protected override string getResourcePath() {
        return "Weapons/Willbreaker";
    }
}
