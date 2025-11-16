public abstract class SpellCast : ISpellCast {
    public ISpellSettings SpellSettings { get { return getSpellSettings(); } }
    public int StartAnimationHash { get { return getStartAnimationHash(); } }
    public string NetworkResourcePath { get { return getNetworkResourcePath(); } }
    public Keybinding Keybinding { get { return getKeybinding(); } }
    public KeybindingType KeybindingType { get { return getKeybindingType(); } }
    public Weapon Weapon { get { return getWeapon(); } }
    public SpellComboPriority Priority { get { return getPriority(); } }
    public SpellAirEnum InAir { get { return getSpellAirEnum(); } }

    protected abstract ISpellSettings getSpellSettings();
    protected abstract int getStartAnimationHash();
    protected abstract string getNetworkResourcePath();
    protected abstract Keybinding getKeybinding();
    protected abstract KeybindingType getKeybindingType();
    protected abstract Weapon getWeapon();
    protected abstract SpellComboPriority getPriority();
    protected abstract SpellAirEnum getSpellAirEnum();
}
