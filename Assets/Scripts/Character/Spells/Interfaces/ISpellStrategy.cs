public interface ISpellStrategy {
    bool IsCooldown { get; }
    ISpellSettings SpellSettings { get; }
    ISpellCast SpellCast { get; }
    void Start(SpellCastExecute spellCastExecute);
    void Update();
    void Stop();
    bool CanExecute(SpellCastExecute spellCastExecute);
}
