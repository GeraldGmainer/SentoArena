using UnityEngine;

public class LightningFootstepPooler : ObjectPooler<LightningFootstepPooler> {
    protected override int getAmount() {
        return 50;
    }
    protected override string getResourcePath() {
        return "Footsteps/LightningFootsteps";
    }
}
