using UnityEngine;

public abstract class SpellChargeStrategyBase : SpellStrategyBase, ISpellChargeStrategy {
    protected float swingTimer;

    protected float ChargeTime { get { return ((IChargeSettings)SpellSettings).ChargeTime; } }

    protected SpellChargeStrategyBase(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        swingTimer = Mathf.Infinity;
        charAnimator.PauseLookIK = true;
        playerController.inputDisabler.SetInputsFromCharge(false);
    }

    public override void Update() {
        base.Update();
        UpdateTimer();
    }

    public override void Stop() {
        base.Stop();
        charAnimator.PauseLookIK = false;
        playerController.inputDisabler.SetInputsFromCharge(true);
    }

    private void UpdateTimer() {
        if (swingTimer != Mathf.Infinity) {
            swingTimer -= Time.deltaTime;
        }
        if (swingTimer <= 0) {
            spellController.stopCasting();
        }
    }

    public virtual void OnKeyUp() {
        if (durationTimer >= ChargeTime) {
            OnSwing();
        }
        else {
            OnCancel();
        }
    }

    protected virtual void OnSwing() {
        HUD.instance.stopCastBarTimer();
        DetermineLookBackTarget();
        ShowCompletedCombo();
        swingTimer = ChargeTime;
        charAnimator.Trigger(AnimatorHashIDs.chargeSwing);
    }

    public virtual void OnCancel() {
        HUD.instance.stopCastBarTimer();
        charAnimator.Trigger(AnimatorHashIDs.spellCancel);
        spellController.stopCasting();
    }

    protected override void HUDUpdate() {
        HUD.instance.startChargeableCastBarTimer(ChargeTime);
    }
}
