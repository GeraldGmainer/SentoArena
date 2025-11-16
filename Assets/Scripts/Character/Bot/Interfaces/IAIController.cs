using UnityEngine;

public interface IAIController {
    Vector3 m_emoryPoint { get; set; }
    CharController m_currentChar { get; set; }
    Transform m_transform { get; }

    void OnDeath();
    void OnRespawn();
    void OnReceiveDamage(SpellDamage spellDamage);
    void OnBotWaypointEnter(BotWaypoint botWaypoint);
    void UpdateStateCubeColor(Color color);
}
