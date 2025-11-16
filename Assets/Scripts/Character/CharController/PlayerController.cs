using UnityEngine;
using BeardedManStudios.Network;

public class PlayerController : CharController {
    public PlayerInputDisabler inputDisabler { get; private set; }

    private PlayerInputController inputController;
    private PlayerSettingsLoader playerSettingsLoader;
    private PlayerInputWeaponChanger inputWeaponChanger = new PlayerInputWeaponChanger();

    protected override void Awake() {
        base.Awake();
        inputController = GetComponent<PlayerInputController>();
        inputDisabler = new PlayerInputDisabler(this);
        playerSettingsLoader = new PlayerSettingsLoader(this);

        inputWeaponChanger.SetCharController(this);
        inputWeaponChanger.SetPlayerInputController(inputController);
        inputWeaponChanger.SetCharSpellController(GetComponent<CharSpellController>());
    }

    protected override void Start() {
        base.Start();
        if (networkController.isNotOwner()) {
            enabled = false;
            return;
        }
        playerSettingsLoader.load();
    }

    protected override void NetworkStart() {
        base.NetworkStart();
        if (!OwningNetWorker.IsServer && networkController.isOwner()) {
            Networking.ClientReady(OwningNetWorker);
        }
    }

    protected override void Update() {
        base.Update();
        if (inputController.GetKeyDown(Keybinding.SUICIDE, InputType.NONE)) {
            receiveDamage(new SpellDamage(1000f, transform.forward));
        }
        if (Input.GetKeyDown(KeyCode.Equals)) {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            Time.timeScale = 0;
        }
        inputWeaponChanger.Update();
    }

    public override void ChangeWeapon(Weapon weapon) {
        base.ChangeWeapon(weapon);
        if ((NetworkingManager.IsOnline && IsOwner) || !NetworkingManager.IsOnline) {
            HUD.instance.changeWeapon(weapon);
        }
    }

    public override void receiveDamage(SpellDamage spellDamage) {
        base.receiveDamage(spellDamage);
        FloatingCombatText.instance.addDamageReceived(spellDamage);
    }

    public override void OnHealthUpdate() {
        base.OnHealthUpdate();
        HUD.instance.setHealth(healthHandler.Health / Settings.instance.charSettings.MaxHealth);
    }

    public override void OnDeath(SpellDamage spellDamage) {
        IngameMenuManager.instance.showRespawnMenu();
        base.OnDeath(spellDamage);
    }
}
