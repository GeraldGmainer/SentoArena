using UnityEngine;

public class BotController : CharController {
    public Weapon m_weapon;

    private IAIController m_AIController;
    private BotActorDriver m_botActorDriver;

    protected override void Awake() {
        base.Awake();
        m_AIController = GetComponent<IAIController>();
        m_botActorDriver = GetComponent<BotActorDriver>();
    }

    protected override void Start() {
        base.Start();
        ChangeWeapon(m_weapon);
    }

    public override void OnDeath(SpellDamage spellDamage) {
        BotManager.instance.onBotDeath(this);
        m_AIController.OnDeath();
        m_botActorDriver.ClearTarget();
        base.OnDeath(spellDamage);
    }

    public override void onRespawn(Vector3 newPosition, Quaternion newRotation) {
        base.onRespawn(newPosition, newRotation);
        m_AIController.OnRespawn();
    }

    public override void receiveDamage(SpellDamage spellDamage) {
        base.receiveDamage(spellDamage);
        m_AIController.OnReceiveDamage(spellDamage);
    }

    public void OnBotWaypointEnter(BotWaypoint botWaypoint) {
        m_AIController.OnBotWaypointEnter(botWaypoint);
    }

}
