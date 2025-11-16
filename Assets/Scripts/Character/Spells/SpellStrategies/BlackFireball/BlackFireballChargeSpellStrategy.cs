using UnityEngine;

public class BlackFireballChargeSpellStrategy : SpellChargeStrategyBase {
    private const float EFFECT_SPAWN_DELAY = 0.5f;

    private BlackFireballSpawner blackFireballSpawner;

    private float effectSpawnTimer;
    private float chargedFinishedTimer;

    public BlackFireballChargeSpellStrategy(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
        blackFireballSpawner = new BlackFireballSpawner(spellController, charHitbox);
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        effectSpawnTimer = 0;
        chargedFinishedTimer = 0;
    }

    public override void Update() {
        base.Update();
        UpdateEffectSpawnTimer();
        UpdateChargedFinishedTimer();
    }

    private void UpdateEffectSpawnTimer() {
        effectSpawnTimer += Time.deltaTime;
        if (effectSpawnTimer != Mathf.Infinity && effectSpawnTimer >= EFFECT_SPAWN_DELAY) {
            Spawn();
            effectSpawnTimer = Mathf.Infinity;
        }
    }

    private void UpdateChargedFinishedTimer() {
        chargedFinishedTimer += Time.deltaTime;
        if (chargedFinishedTimer != Mathf.Infinity && chargedFinishedTimer >= ChargeTime) {
            CameraShake();
            chargedFinishedTimer = Mathf.Infinity;
        }
    }

    private void Spawn() {
        blackFireballSpawner.spawn("SpellBlackFireballCharge", (ThrowableSpellSettings)spellCastExecute.SpellSettings);
    }

    protected override void OnSwing() {
        base.OnSwing();
        spellController.RegisterSpellAnimationEvent(Shoot);
    }

    private void Shoot() {
        CameraShake();
        if (playerCamera.IsLookingBack) {
            blackFireballSpawner.StartMoving(lookBackTarget);
        }
        else {
            blackFireballSpawner.StartMoving(DetermineTarget(blackFireballSpawner.getPosition()));
        }
    }

    public override void OnCancel() {
        base.OnCancel();
        blackFireballSpawner.destroy();
    }
}
