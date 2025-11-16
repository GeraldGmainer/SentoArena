using UnityEngine;

public class BotSearchingState : BotStateBase {
    private const float MAX_SEE_DISTANCE = 200f;
    private const float ALWAYS_SEE_DISTANCE = 2f;
    private const float FIELD_OF_VIEW_ANGLE = 180;

    private BotWaypoint m_currentWaypoint;
    private BotWaypointFinder m_waypointFinder;

    public BotSearchingState(IAIController AIController) : base(AIController) {
        m_waypointFinder = new BotWaypointFinder();
    }

    public override void OnEnter() {
        base.OnEnter();
        m_AIController.m_emoryPoint = Vector3.zero;
        m_AIController.UpdateStateCubeColor(Color.green);
        m_currentWaypoint = m_waypointFinder.Find(m_transform.position);
        m_botActorDriver.Target = m_currentWaypoint.transform;
    }

    public override void OnUpdate() {
        base.OnUpdate();
    }
}
