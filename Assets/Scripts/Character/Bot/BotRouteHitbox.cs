using UnityEngine;

public class BotRouteHitbox : MonoBehaviour {
    public BotController m_botController;

    void OnTriggerEnter(Collider collider) {
        m_botController.OnBotWaypointEnter(collider.GetComponent<BotWaypoint>());
    }
}
