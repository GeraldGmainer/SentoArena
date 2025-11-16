public delegate void WeaponChangeCallback();

public interface ICharSpellController {
    bool IsCasting { get; }
    void RequestWeaponChange(WeaponChangeCallback callback);
}
