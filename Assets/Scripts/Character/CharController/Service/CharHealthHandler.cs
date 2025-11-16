using UnityEngine;

public class CharHealthHandler {
    public float Health { get; private set; }

    private float maxHealth;
    private ICharController charController;

    public CharHealthHandler(ICharController charController, float maxHealth) {
        this.charController = charController;
        this.maxHealth = maxHealth;
    }

    public void Start() {
        UpdateHealth(maxHealth);
    }

    public void ReceiveDamage(SpellDamage spellDamage) {
        UpdateHealth(Health - spellDamage.damage);
        if (Health <= 0) {
            charController.OnDeath(spellDamage);
        }
    }

    private void UpdateHealth(float value) {
        Health = Mathf.Clamp(value, 0, maxHealth);
        charController.OnHealthUpdate();
    }
}
