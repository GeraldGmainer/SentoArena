public class LightningPort : SpellPort {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.lightningPort;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.lightningPort;
    }

    protected override string getNetworkResourcePath() {
        return null;
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE4;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY_DOWN;
    }

    protected override Weapon getWeapon() {
        return Weapon.SAI;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.HIGH;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
