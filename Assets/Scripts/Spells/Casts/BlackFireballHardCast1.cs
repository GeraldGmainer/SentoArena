public class BlackFireballHardCast1 : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.blackFireballHard;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.blackFireballHard1;
    }

    protected override string getNetworkResourcePath() {
        return "SpellBlackFireballHard";
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE2;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY_DOWN;
    }

    protected override Weapon getWeapon() {
        return Weapon.SCYTHE;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.LOW_MEDIUM;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
