using UnityEngine;
using BeardedManStudios.Network;

public class BlackFireballSpawner {
    private Transform transform;
    private CharHitbox charHitbox;

    private SpellBlackFireballBase blackFireball;

    public BlackFireballSpawner(CharSpellController spellController, CharHitbox charHitbox) {
        transform = spellController.transform;
        this.charHitbox = charHitbox;
    }

    public void spawn(string path, ThrowableSpellSettings spellSettings) {
        blackFireball = null;
        Networking.Instantiate(path, NetworkReceivers.All, onSpawn);
    }

    private void onSpawn(SimpleNetworkedMonoBehavior go) {
        blackFireball = go.GetComponent<SpellBlackFireballBase>();
        blackFireball.IgnoreCollision(charHitbox.getHitbox());
        blackFireball.Reparent(transform);
    }

    public void StartMoving(Vector3 target) {
        blackFireball.startMoving(target);
    }

    public Vector3 getPosition() {
        return blackFireball.transform.position;
    }

    public void destroy() {
        if (blackFireball != null) {
            blackFireball.destroy();
        }
    }
}
