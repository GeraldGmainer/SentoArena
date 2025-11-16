using UnityEngine;

public class BlackFireballTaidenSpellStrategy : SpellChargeStrategyBase {
    private const float TOP_SPAWN_DELAY = 2f;
    private const float BOTTOM_SPAWN_DELAY = 1f;

    private bool isDoubleSwing;
    private float topSpawnDelayTimer;
    private float bottomSpawnDelayTimer;
    private float firstChargedFinishedTimer;
    private float secondChargedFinishedTimer;

    private BlackFireballSpawner blackFireballSpawnerTop;
    private BlackFireballSpawner blackFireballSpawnerBottom;

    public BlackFireballTaidenSpellStrategy(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
        blackFireballSpawnerTop = new BlackFireballSpawner(spellController, charHitbox);
        blackFireballSpawnerBottom = new BlackFireballSpawner(spellController, charHitbox);
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        topSpawnDelayTimer = 0;
        bottomSpawnDelayTimer = 0;
        firstChargedFinishedTimer = 0;
        secondChargedFinishedTimer = 0;
        //playerController.StartTaiden();
    }

    public override void Update() {
        base.Update();
        UpdateTopTimer();
        UpdateBottomTimer();
        UpdateFirstChargedFinishedTimer();
        UpdateSecondChargedFinishedTimer();
    }

    private void UpdateTopTimer() {
        topSpawnDelayTimer += Time.deltaTime;
        if (topSpawnDelayTimer != Mathf.Infinity && topSpawnDelayTimer >= TOP_SPAWN_DELAY) {
            SpawnTop();
            topSpawnDelayTimer = Mathf.Infinity;
        }
    }

    private void UpdateBottomTimer() {
        bottomSpawnDelayTimer += Time.deltaTime;
        if (bottomSpawnDelayTimer != Mathf.Infinity && bottomSpawnDelayTimer >= BOTTOM_SPAWN_DELAY) {
            SpawnBottom();
            bottomSpawnDelayTimer = Mathf.Infinity;
        }
    }

    private void UpdateFirstChargedFinishedTimer() {
        firstChargedFinishedTimer += Time.deltaTime;
        if (firstChargedFinishedTimer != Mathf.Infinity && firstChargedFinishedTimer >= Settings.instance.blackFireballTaiden.ChargeTime) {
            HUD.instance.startChargeableCastBarTimer(Settings.instance.blackFireballTaiden.ChargeTimeDouble);
            CameraShake();
            firstChargedFinishedTimer = Mathf.Infinity;
        }
    }

    private void UpdateSecondChargedFinishedTimer() {
        secondChargedFinishedTimer += Time.deltaTime;
        if (secondChargedFinishedTimer != Mathf.Infinity && secondChargedFinishedTimer >= Settings.instance.blackFireballTaiden.ChargeTime + Settings.instance.blackFireballTaiden.ChargeTimeDouble) {
            secondChargedFinishedTimer = Mathf.Infinity;
            CameraShake();
        }
    }

    private void SpawnTop() {
        blackFireballSpawnerTop.spawn("SpellBlackFireballTaidenTop", (ThrowableSpellSettings)spellCastExecute.SpellSettings);
    }

    private void SpawnBottom() {
        blackFireballSpawnerBottom.spawn("SpellBlackFireballTaidenBottom", (ThrowableSpellSettings)spellCastExecute.SpellSettings);
    }

    public override void Stop() {
        base.Stop();
        //playerController.StopTaiden();
    }

    protected override void OnSwing() {
        HUD.instance.stopCastBarTimer();
        DetermineLookBackTarget();
        ShowCompletedCombo();
        spellController.RegisterSpellAnimationEvent(ShootBottom);
        topSpawnDelayTimer = Mathf.Infinity;
        bottomSpawnDelayTimer = Mathf.Infinity;

        if (durationTimer < Settings.instance.blackFireballTaiden.ChargeTime + Settings.instance.blackFireballTaiden.ChargeTimeDouble) {
            SingleSwing();
        }
        else {
            DoubleSwing();
        }
    }

    private void SingleSwing() {
        blackFireballSpawnerTop.destroy();
        charAnimator.Trigger(AnimatorHashIDs.chargeSwing);
        swingTimer = Settings.instance.blackFireballTaiden.SwingAnimationDuration;
    }

    private void DoubleSwing() {
        isDoubleSwing = true;
        charAnimator.Trigger(AnimatorHashIDs.blackFireballTaidenDoubleSwing);
        swingTimer = Settings.instance.blackFireballTaiden.SwingAnimationDurationDouble;
    }

    private void ShootTop() {
        CameraShake();
        if (playerCamera.IsLookingBack) {
            blackFireballSpawnerTop.StartMoving(lookBackTarget);
        }
        else {
            blackFireballSpawnerTop.StartMoving(DetermineTarget(blackFireballSpawnerTop.getPosition()));
        }

    }

    private void ShootBottom() {
        CameraShake();
        if (playerCamera.IsLookingBack) {
            blackFireballSpawnerBottom.StartMoving(lookBackTarget);
        }
        else {
            blackFireballSpawnerBottom.StartMoving(DetermineTarget(blackFireballSpawnerBottom.getPosition()));
        }
        if (isDoubleSwing) {
            spellController.RegisterSpellAnimationEvent(ShootTop);
        }
    }

    public override void OnCancel() {
        base.OnCancel();
        blackFireballSpawnerTop.destroy();
        blackFireballSpawnerBottom.destroy();
    }
}
