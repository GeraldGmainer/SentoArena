public interface IWeaponComponent {
    IObjectPooler FootstepPooler { get; }
    float LeftHandAnimationLayerWeight { get; }
    float RightHandAnimationLayerWeight { get; }
    WeaponWield WeaponWield { get; }

    void Disable();
}
