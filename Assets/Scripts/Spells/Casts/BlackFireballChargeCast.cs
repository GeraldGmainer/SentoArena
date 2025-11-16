public class BlackFireballChargeCast : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.blackFireballCharge;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.blackFireballCharge;
    }

    protected override string getNetworkResourcePath() {
        return "SpellBlackFireballCharge";
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
        return SpellComboPriority.MEDIUM_HIGH;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
