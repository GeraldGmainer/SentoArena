public class BlackFireballTaidenCast : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.blackFireballTaiden;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.blackFireballTaiden;
    }

    protected override string getNetworkResourcePath() {
        return "SpellBlackFireballTaiden";
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE2;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY;
    }

    protected override Weapon getWeapon() {
        return Weapon.SCYTHE;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.HIGH;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
