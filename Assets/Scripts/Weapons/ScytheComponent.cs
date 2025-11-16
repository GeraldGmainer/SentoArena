using UnityEngine;

public class ScytheComponent : WeaponComponentBase {
    //public GameObject Scythe;
    //public GameObject ScytheTaiden;

    void OnEnable() {
        //Scythe.SetActive(true);
        //ScytheTaiden.SetActive(false);
    }

    protected override IObjectPooler getPooler() {
        return ScythePooler.instance;
    }

    protected override IObjectPooler getFootstepPooler() {
        return BlackFireballFootstepPooler.instance;
    }

    protected override float getLeftHandAnimationLayerWeight() {
        return 0;
    }

    protected override float getRightHandAnimationLayerWeight() {
        return 1;
    }

    protected override WeaponWield getWeaponWield() {
        return WeaponWield.RIGHT;
    }
}
