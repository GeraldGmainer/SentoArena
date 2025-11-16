public class SaiComponent : WeaponComponentBase {
    protected override IObjectPooler getPooler() {
        return SaiPooler.instance;
    }

    protected override IObjectPooler getFootstepPooler() {
        return LightningFootstepPooler.instance;
    }

    protected override float getLeftHandAnimationLayerWeight() {
        return 1;
    }

    protected override float getRightHandAnimationLayerWeight() {
        return 1;
    }

    protected override WeaponWield getWeaponWield() {
        return WeaponWield.DUAL;
    }
}
