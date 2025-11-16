using UnityEngine;

public class BotStateBase : IBotState {
    protected IAIController m_AIController;
    protected BotActorDriver m_botActorDriver;
    protected Transform m_transform;

    public BotStateBase(IAIController AIController) {
        m_AIController = AIController;
        m_transform = AIController.m_transform;
    }

    public virtual void OnEnter() {
    }

    public virtual void OnExit() {
    }

    public virtual void OnReceiveDamage(SpellDamage spellDamage) {
    }

    public virtual void OnBotWaypointEnter(BotWaypoint botWaypoint) {
    }

    public virtual void OnUpdate() {
    }

    public void setActorDriver(BotActorDriver botActorDriver) {
        m_botActorDriver = botActorDriver;
    }

}
