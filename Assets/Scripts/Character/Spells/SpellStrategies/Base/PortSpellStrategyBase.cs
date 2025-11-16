using UnityEngine;

public abstract class PortSpellStrategyBase : SpellStrategyBase {
    protected IPortSettings PortSettings { get { return (IPortSettings)SpellSettings; } }
    protected PortResult portResult;

    private Vector3 startPosition;
    private PortGravityHandler portGravityHandler;
    private PortTargetDeterminer portTargetDeterminer;

    private float portDelayTimer;

    protected PortSpellStrategyBase(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
        portGravityHandler = new PortGravityHandler(transform);
        portTargetDeterminer = new PortTargetDeterminer(transform);
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        portDelayTimer = 0;
        startPosition = transform.position;
        playerController.inputDisabler.SetInputsFromPort(false);
        CameraShake(PortSettings.CameraShakeDelay);
    }

    public override void Update() {
        base.Update();
        UpdateTimer();
    }

    private void UpdateTimer() {
        portDelayTimer += Time.deltaTime;
        if (portDelayTimer != Mathf.Infinity && portDelayTimer >= PortSettings.PortDelay) {
            OnPortDelay();
            portDelayTimer = Mathf.Infinity;
        }
    }

    protected virtual void OnPortDelay() {
        portGravityHandler.handle(portResult);
        transform.position = portResult.target;
        //RPC("RPC_updatePosition", NetworkReceivers.Others, portResult.target);
        //Time.timeScale = 0.0f;

        if (TestsceneHUD.instance) {
            TestsceneHUD.instance.setPortedDistance(Vector3.Distance(startPosition, transform.position));
        }
        playerCamera.portSmoothly();
    }

    /*
    [BRPC]
    public void RPC_updatePosition(Vector3 targetPosition) {
        transform.position = targetPosition;
    }
    */

    public override void Stop() {
        base.Stop();
        playerController.inputDisabler.SetInputsFromPort(true);
    }

    protected override void HUDUpdate() {
        ShowCompletedCombo();
        HUD.instance.startPortBarTimer(SpellSettings.Cooldown);
    }

    public override bool CanExecute(SpellCastExecute spellCastExecute) {
        portResult = portTargetDeterminer.determine((IPortSettings)spellCastExecute.SpellSettings);
        if (!portResult.isValid) {
            PlayerLog.instance.addErrorMessage(portResult.errorMessage);
            return false;
        }
        return base.CanExecute(spellCastExecute);
    }
}
