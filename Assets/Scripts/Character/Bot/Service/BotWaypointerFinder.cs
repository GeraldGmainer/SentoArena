using UnityEngine;

public class BotWaypointFinder {
    private BotWaypoint m_currentWaypoint;
    private BotRoute m_currentBotRoute;

    public BotWaypointFinder() {
    }

    public BotWaypoint Find(Vector3 position) {
        if (m_currentBotRoute == null) {
            DetermineRdmRoute();
        }
        return findClosestWaypoint(position);
    }

    private void DetermineRdmRoute() {
        int rdm = Random.Range(0, BotManager.instance.BotRoutes.Length - 1);
        m_currentBotRoute = BotManager.instance.BotRoutes[rdm];
    }

    private BotWaypoint findClosestWaypoint(Vector3 position) {
        BotWaypoint closest = null;
        float distance = Mathf.Infinity;
        for (int i = 0; i < m_currentBotRoute.BotWaypoints.Length; i++) {
            if (m_currentBotRoute.BotWaypoints[i].transform.Equals(m_currentWaypoint)) {
                continue;
            }

            Vector3 diff = m_currentBotRoute.BotWaypoints[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = m_currentBotRoute.BotWaypoints[i];
                distance = curDistance;
            }
        }
        return closest;
    }
}
