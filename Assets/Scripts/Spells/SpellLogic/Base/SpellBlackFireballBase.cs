using UnityEngine;
using BeardedManStudios.Network;

public abstract class SpellBlackFireballBase : SimpleNetworkedMonoBehavior, IThrowableSpell {
    protected Collider spellCollider;
    protected BlackFireballMover spellMover;
    protected BlackFireballEffect blackFireballEffect;
    protected ThrowableSpellEnvironmentCollider environmentCollider;

    private SpellDamageDealer spellDamageDealer;
    private SpellCollisionDetector collisionDetector;

    protected virtual void Awake() {
        spellCollider = GetComponent<Collider>();
        spellDamageDealer = GetComponent<SpellDamageDealer>();
        environmentCollider = GetComponentInChildren<ThrowableSpellEnvironmentCollider>();
        environmentCollider.setParent(this);
        spellMover = new BlackFireballMover(this);
        collisionDetector = new SpellCollisionDetector(this, getSpellSettings().MaxRange);
    }

    protected virtual void Start() {
        showBlackFireballEffect();
    }

    protected virtual void showBlackFireballEffect() {
        blackFireballEffect = getEffectPooler().retrieveObject().GetComponent<BlackFireballEffect>();
        blackFireballEffect.transform.parent = transform;
        blackFireballEffect.transform.localPosition = Vector3.zero;
        blackFireballEffect.transform.localRotation = Quaternion.identity;
        blackFireballEffect.start();
    }

    protected override void NetworkStart() {
        base.NetworkStart();
        if (!IsOwner) {
            Reparent(GameObjectFinder.findPlayerWithOwnerId(OwnerId));
        }
    }

    public virtual void Reparent(Transform player) {
        transform.parent = GameObjectFinder.inChildByName(player, getReparentPosition()).transform;
        transform.localPosition = Vector3.zero;
    }

    protected virtual void FixedUpdate() {
        spellMover.fixedUpdate(IsOwner);
        collisionDetector.update();
    }

    public void startMoving(Vector3 target) {
        float speed = getSpellSettings().Speed;
        float maxRange = getSpellSettings().MaxRange;
        spellMover.startMoving(target, speed, maxRange);
        spellCollider.enabled = true;
        environmentCollider.enable();
        collisionDetector.setTarget(target);
        blackFireballEffect.startMoving();
        RPC("RPC_startMoving", NetworkReceivers.Others, target, transform.position, speed, maxRange);
    }

    [BRPC]
    public void RPC_startMoving(Vector3 target, Vector3 startPosition, float speed, float maxRange) {
        transform.position = startPosition;
        spellMover.startMoving(target, speed, maxRange);
    }

    void OnTriggerEnter(Collider other) {
        onCharacterHit(other);
    }

    private void onCharacterHit(Collider other) {
        spellDamageDealer.DealDamage(other, new SpellDamage(getSpellSettings().Damage, transform.forward));
        OnCollision(other.transform, collisionDetector.anticipatedCollision);
    }

    public void onEnvironmentalHit(Collider other) {
        onEnvironmentalHit(other.transform, collisionDetector.anticipatedCollision);
    }

    private void onEnvironmentalHit(Transform hitObject, RaycastHit hit) {
        OnCollision(hitObject, collisionDetector.anticipatedCollision);
    }

    private void OnCollision(Transform hitObject, RaycastHit hit) {
        RPC_createExplosion(hit.point);
        RPC("RPC_createExplosion", NetworkReceivers.Others, hit.point);
        destroy();
    }

    [BRPC]
    public void RPC_createExplosion(Vector3 point) {
        getExplosionPooler().retrieveObject(point);
    }

    public void IgnoreCollision(Collider otherCollider) {
        Physics.IgnoreCollision(otherCollider, spellCollider);
    }

    public void destroy() {
        Networking.Destroy(this);
    }

    protected override void OnDestroy() {
        if (getEffectPooler() != null) {
            blackFireballEffect.releaseSmoke();
            getEffectPooler().disableObject(blackFireballEffect.gameObject);
        }
        base.OnDestroy();
    }

    protected abstract IObjectPooler getEffectPooler();
    protected abstract IObjectPooler getExplosionPooler();
    protected abstract string getReparentPosition();
    protected abstract IThrowableSpellSettings getSpellSettings();
}
