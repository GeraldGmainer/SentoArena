using UnityEngine;
using BeardedManStudios.Network;

public abstract class CharSpellController : CharMonoBehaviour, ICharSpellController {
    public const float COMBO_RESET_TIME = 1f;
    public const float CHARGE_DELAY_TIME = 0.2f;

    public ISpellStrategy CurrentSpell { get; private set; }
    public ComboHistory ComboHistory { get; private set; }
    public bool IsCasting { get { return CurrentSpell != null; } }
    public bool IsCharging { get { return IsCasting && CurrentSpell is ISpellChargeStrategy; } }

    private WeaponChangeCallback weaponChangeCallbackFunction;
    public delegate void NextSpellAnimationEvent();
    private NextSpellAnimationEvent nextSpellAnimationEventFunction;
    private NextSpellAnimationEvent nextSpellAnimationEventTemp;

    protected override void Awake() {
        base.Awake();
        ComboHistory = new ComboHistory();
    }

    protected override void Start() {
        base.Start();
        if (networkController.isNotOwner()) {
            enabled = false;
        }
    }

    protected override void OnEnable() {
        base.OnEnable();
        CurrentSpell = null;
        ComboReset();
    }

    protected override void Update() {
        base.Update();
        if (CurrentSpell != null) {
            CurrentSpell.Update();
        }
    }

    public virtual void StartCasting(ISpellStrategy charSpell) {
        CurrentSpell = charSpell;
    }

    public virtual void stopCasting() {
        CurrentSpell.Stop();
        CurrentSpell = null;
        RespectWeaponChange();
    }

    public virtual void CancelCharge() {
    }

    public void ComboReset() {
        //Debug.Log("comboReset");
        ComboHistory.Reset();
    }

    public void RespectWeaponChange() {
        if (weaponChangeCallbackFunction != null) {
            weaponChangeCallbackFunction();
            weaponChangeCallbackFunction = null;
        }
    }

    public void RequestWeaponChange(WeaponChangeCallback callback) {
        weaponChangeCallbackFunction = callback;
    }

    public void SpellAnimationEvent() {
        if (nextSpellAnimationEventFunction != null) {
            //necessary to assign 2nd animation event in first animation event
            nextSpellAnimationEventTemp = nextSpellAnimationEventFunction;
            nextSpellAnimationEventFunction = null;
            nextSpellAnimationEventTemp();
        }
    }

    public void RegisterSpellAnimationEvent(NextSpellAnimationEvent nextSpellAnimationEvent) {
        nextSpellAnimationEventFunction = nextSpellAnimationEvent;
    }
}

