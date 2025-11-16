using UnityEngine;

public class PlayerSpellController : CharSpellController {
    private SpellExecuter spellExecuter;
    private PlayerInputController inputController;
    private SpellCastDeterminer spellCastDeterminer;
    private SpellInputDeterminer spellInputDeterminer;
    private SpellTimer spellTimer;
    private PlayerCamera playerCamera;

    private Keybinding lastKeybinding;
    private float chargeCanBeStartedAtTime;

    protected override void Awake() {
        base.Awake();
        spellTimer = new SpellTimer(this);
        spellExecuter = new SpellExecuter(this, spellTimer);
        spellCastDeterminer = new SpellCastDeterminer(this);
        spellInputDeterminer = new SpellInputDeterminer(this);

        playerCamera = GetComponent<PlayerCamera>();
        inputController = GetComponent<PlayerInputController>();
    }

    protected override void OnEnable() {
        base.OnEnable();
        lastKeybinding = Keybinding.NONE;
        chargeCanBeStartedAtTime = Mathf.Infinity;
    }

    protected override void Update() {
        base.Update();
        if(playerCamera.IsLookingBack) {
            return;
        }
        HandleKeydown();
        HandleKey();
        HandleKeyUp();
    }

    public void HandleKeydown() {
        if (CanExecuteFireDownSpell()) {
            spellExecuter.Execute(spellCastDeterminer.Determine(spellInputDeterminer.determineFireDown(), KeybindingType.KEY_DOWN));
        }
    }

    private bool CanExecuteFireDownSpell() {
        return spellInputDeterminer.IsAnyFireDown() && !IsCharging && !spellExecuter.cannotExecute();
    }

    public void HandleKey() {
        if (CanExecuteChargeSpell()) {
            spellTimer.stopComboResetCoroutine();
            spellExecuter.Execute(spellCastDeterminer.Determine(lastKeybinding, KeybindingType.KEY));
            lastKeybinding = Keybinding.NONE;
            chargeCanBeStartedAtTime = Mathf.Infinity;
        }
    }

    private bool CanExecuteChargeSpell() {
        return !IsCasting && lastKeybinding != Keybinding.NONE && Time.time >= chargeCanBeStartedAtTime;
    }

    public void HandleKeyUp() {
        if (IsChargingReleasedTooEarly()) {
            lastKeybinding = Keybinding.NONE;
            chargeCanBeStartedAtTime = Mathf.Infinity;
            //Debug.Log("ChargingReleasedTooEarly");
        }

        if (ShouldExecuteChargeKeyUp()) {
            spellExecuter.ExecuteChargeKeyUp();
        }
    }

    private bool IsChargingReleasedTooEarly() {
        return lastKeybinding != Keybinding.NONE && !Input.GetButton(KeybindingsFactory.convert(lastKeybinding));
    }

    private bool ShouldExecuteChargeKeyUp() {
        return IsCharging && inputController.GetKeyUp(CurrentSpell.SpellCast.Keybinding, InputType.SPELL);
    }

    public override void StartCasting(ISpellStrategy charSpell) {
        base.StartCasting(charSpell);
        lastKeybinding = CurrentSpell.SpellCast.Keybinding;
    }

    public override void stopCasting() {
        base.stopCasting();
        spellTimer.StartComboResetTimer();
        chargeCanBeStartedAtTime = Time.time + CHARGE_DELAY_TIME;
    }

    public override void CancelCharge() {
        base.CancelCharge();
        ((ISpellChargeStrategy)CurrentSpell).OnCancel();
    }
}
