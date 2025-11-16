using UnityEngine;

public abstract class WeaponComponentBase : MonoBehaviour, IWeaponComponent {
    public IObjectPooler FootstepPooler { get { return getFootstepPooler(); } }
    public float LeftHandAnimationLayerWeight { get { return getLeftHandAnimationLayerWeight(); } }
    public float RightHandAnimationLayerWeight { get { return getRightHandAnimationLayerWeight(); } }
    public WeaponWield WeaponWield { get { return getWeaponWield(); } }

    public void Disable() {
        getPooler().disableObject(gameObject);
    }

    protected abstract IObjectPooler getPooler();
    protected abstract IObjectPooler getFootstepPooler();
    protected abstract float getLeftHandAnimationLayerWeight();
    protected abstract float getRightHandAnimationLayerWeight();
    protected abstract WeaponWield getWeaponWield();
}
