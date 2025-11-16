using UnityEngine;

public abstract class ThrowableSpellSettings : SpellSettingsBase, IThrowableSpellSettings {
    [SerializeField]
    protected float speed = 150f;
    [SerializeField]
    protected float damage = 30f;

    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
}
