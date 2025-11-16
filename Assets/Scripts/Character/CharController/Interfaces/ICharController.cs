public interface ICharController  {
    Weapon currentWeapon { get; }

    void OnDeath(SpellDamage spellDamage);
    void OnHealthUpdate();
    void ChangeWeapon(Weapon weapon);
}
