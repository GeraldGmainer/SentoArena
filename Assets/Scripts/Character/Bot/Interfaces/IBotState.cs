public interface IBotState  {
    void OnEnter();
    void OnUpdate();
    void OnExit();
    void OnReceiveDamage(SpellDamage spellDamage);
    void OnBotWaypointEnter(BotWaypoint botWaypoint);
}
