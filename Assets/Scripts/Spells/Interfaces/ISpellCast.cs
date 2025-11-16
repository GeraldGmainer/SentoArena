public interface ISpellCast {
    ISpellSettings SpellSettings { get; }
    int StartAnimationHash { get; }
    string NetworkResourcePath { get; }
    Keybinding Keybinding { get; }
    KeybindingType KeybindingType { get; }
    Weapon Weapon { get; }
    SpellComboPriority Priority { get; }
    SpellAirEnum InAir { get; }
}
