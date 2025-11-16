using UnityEngine;
using System.Collections;

//each spell with cooldown must be own strategy !

public abstract class SpellStrategyBase : ISpellStrategy {
    public bool IsCooldown { get; private set; }
    public ISpellSettings SpellSettings { get { return spellCastExecute.SpellSettings; } }
    public ISpellCast SpellCast { get { return spellCastExecute.SpellCast; } }

    protected Transform transform;
    protected CharHitbox charHitbox;
    protected CharAnimator charAnimator;
    protected PlayerCamera playerCamera;
    protected CharSpellController spellController;
    protected PlayerController playerController;

    protected float durationTimer;
    protected Vector3 lookBackTarget;
    protected SpellCastExecute spellCastExecute;

    protected SpellStrategyBase(CharSpellController spellController, CharHitbox charHitbox) {
        this.spellController = spellController;
        this.charHitbox = charHitbox;
        transform = spellController.transform;
        charAnimator = spellController.GetComponent<CharAnimator>();
        playerCamera = spellController.GetComponent<PlayerCamera>();
        playerController = spellController.GetComponent<PlayerController>();
    }

    public virtual void Start(SpellCastExecute spellCastExecute) {
        this.spellCastExecute = spellCastExecute;
        charAnimator.Trigger(spellCastExecute.SpellCast.StartAnimationHash);
        charAnimator.StartCasting();
        StartCooldownTimer();
        HUDUpdate();
        durationTimer = 0;
    }

    public virtual void Update() {
        durationTimer += Time.deltaTime;
        if (!(this is ISpellChargeStrategy)) {
            StopCastingAtAnimationEnd();
        }
    }

    public virtual void Stop() {
    }

    protected virtual void HUDUpdate() {
        HUD.instance.startSingleCastBarTimer(SpellSettings.AnimationDuration);
        ShowCompletedCombo();
    }

    protected virtual void ShowCompletedCombo() {
        if (spellCastExecute.isComboCompleted) {
            HUD.instance.addCombo(spellCastExecute.comboName);
        }
    }

    private void StartCooldownTimer() {
        if (SpellSettings.Cooldown > 0) {
            spellController.StartCoroutine(CooldownTimer());
        }
    }

    private IEnumerator CooldownTimer() {
        IsCooldown = true;
        yield return new WaitForSeconds(SpellSettings.Cooldown);
        IsCooldown = false;
    }

    protected void DetermineLookBackTarget() {
        lookBackTarget = DetermineTarget(transform.position);
    }

    protected Vector3 DetermineTarget(Vector3 spawnPosition) {
        return SpellTargetDeterminer.determineRespectingClosestCollision(transform, spawnPosition, SpellSettings.MaxRange);
    }

    protected void CameraShake() {
        if (SpellSettings.CameraShake != CameraShakeEnum.NONE && playerCamera.IsThirdPerson) {
            CameraShaker.Instance.Shake(SpellSettings.CameraShake);
        }
    }

    protected void CameraShake(float delay) {
        if (SpellSettings.CameraShake != CameraShakeEnum.NONE && playerCamera.IsThirdPerson) {
            CameraShaker.Instance.Shake(SpellSettings.CameraShake, delay);
        }
    }

    protected void StopCastingAtAnimationEnd() {
        if (durationTimer >= SpellSettings.AnimationDuration) {
            spellController.stopCasting();
            durationTimer = Mathf.Infinity;
        }
    }

    public virtual bool CanExecute(SpellCastExecute spellCastExecute) {
        if (IsCooldown) {
            PlayerLog.instance.addErrorMessage("Spell is on cooldown");
            return false;
        }
        return true;
    }
}
