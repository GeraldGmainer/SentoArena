public class KatanaComponent : WeaponComponentBase {
    protected override IObjectPooler getPooler() {
        return KatanaPooler.instance;
    }

    protected override IObjectPooler getFootstepPooler() {
        return null;
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
