public class LightningLightCast1 : SpellCast {
    protected override ISpellSettings getSpellSettings() {
        return Settings.instance.lightningLight;
    }

    protected override int getStartAnimationHash() {
        return AnimatorHashIDs.lightningLight1;
    }

    protected override string getNetworkResourcePath() {
        return null;
    }

    protected override Keybinding getKeybinding() {
        return Keybinding.FIRE1;
    }

    protected override KeybindingType getKeybindingType() {
        return KeybindingType.KEY_DOWN;
    }

    protected override Weapon getWeapon() {
        return Weapon.SAI;
    }

    protected override SpellComboPriority getPriority() {
        return SpellComboPriority.LOW;
    }

    protected override SpellAirEnum getSpellAirEnum() {
        return SpellAirEnum.WAYNE;
    }
}
