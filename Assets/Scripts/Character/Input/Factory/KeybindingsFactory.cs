using UnityEngine;

public static class KeybindingsFactory {
    public static string convert(Keybinding keybinding) {
        switch (keybinding) {
            case Keybinding.HORIZONTAL:
            return "Horizontal";
            case Keybinding.VERTICAL:
            return "Vertical";
            case Keybinding.JUMP:
            return "Jump";

            case Keybinding.MOUSE_X:
            return "MouseX";
            case Keybinding.MOUSE_Y:
            return "MouseY";
            case Keybinding.MOUSE_SCROLL_WHEEL:
            return "MouseScrollWheel";
            case Keybinding.LOOK_BACK:
            return "LookBack";

            case Keybinding.FIRE1:
            return "Fire1";
            case Keybinding.FIRE2:
            return "Fire2";
            case Keybinding.FIRE3:
            return "Fire3";
            case Keybinding.FIRE4:
            return "Fire4";
            case Keybinding.CHANGE_WEAPON:
            return "ChangeWeapon";

            case Keybinding.TOGGLE_CHAT_VISIBILTY:
            return "ToggleChatVisibility";
            case Keybinding.TOGGLE_HUD_VISIBILTY:
            return "ToggleHUDVisibility";
            case Keybinding.SUBMIT:
            return "Submit";
            case Keybinding.CANCEL:
            return "Cancel";
            case Keybinding.SUICIDE:
            return "Suicide";
        }
        Debug.LogError("KeybindingsFactory unknown keybinding");
        return null;
    }
}
