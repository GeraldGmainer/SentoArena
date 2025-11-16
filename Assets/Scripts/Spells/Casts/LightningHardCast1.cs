public class LightningHardCast1 : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.lightningHard;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.lightningHard1;
    }

    protected override string getNetworkResourcePath() {
        return null;
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE2;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY_DOWN;
    }

    protected override Weapon getWeapon() {
        return Weapon.SAI;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.MEDIUM;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
