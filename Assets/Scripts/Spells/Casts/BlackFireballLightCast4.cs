public class BlackFireballLightCast4 : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.blackFireballLight;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.blackFireballLight4;
    }

    protected override string getNetworkResourcePath() {
        return "SpellBlackFireballLight";
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE1;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY_DOWN;
    }

    protected override Weapon getWeapon() {
        return Weapon.SCYTHE;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.LOW;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
