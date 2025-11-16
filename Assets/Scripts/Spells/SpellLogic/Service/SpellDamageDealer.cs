using UnityEngine;
using BeardedManStudios.Network;

public class SpellDamageDealer : SimpleNetworkedMonoBehavior {

    public void DealDamage(Collider other, SpellDamage spellDamage) {
        if ((NetworkingManager.IsOnline && !IsOwner) || other == null) {
            return;
        }
        CharHitbox hitbox = other.GetComponent<CharHitbox>();
        if (hitbox != null) {
            FloatingCombatText.instance.addDamageDone(spellDamage);
            hitbox.CharController.receiveDamage(spellDamage);
        }
        else {
            Debug.Log("null");
        }
    }
}
