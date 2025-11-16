public class BlackFireballHardAirCast : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.blackFireballHardCombo;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.blackFireballHardAir;
    }

    protected override string getNetworkResourcePath() {
        return "SpellBlackFireballHardCombo";
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
        return SpellComboPriority.MEDIUM;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.AIR;
    }
}
