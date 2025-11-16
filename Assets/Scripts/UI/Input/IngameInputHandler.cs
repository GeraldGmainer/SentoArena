using UnityEngine;

public class IngameInputHandler : MonoBehaviour {
    void Update() {
        if (Settings.instance.standalone.isStandalone) {
            return;
        }
        handleHUDVisibility();
        handleMenuInput();
        handleChatInput();
    }

    private void handleHUDVisibility() {
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.TOGGLE_HUD_VISIBILTY))) {
            HUD.instance.toggleHUDVisibility();
        }
    }

    private static void handleMenuInput() {
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.CANCEL)) && !Chat.instance.isChatOpen && !PlayerManager.instance.isPlayerDead()) {
            if (PlayerManager.instance.isPlayerCharging()) {
                PlayerManager.instance.player.GetComponent<CharSpellController>().CancelCharge();
            }
            else {
                IngameMenuManager.instance.onCancel();
            }
        }
    }

    private static void handleChatInput() {
        if (IngameMenuManager.instance.isMenuOpen) {
            return;
        }
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.SUBMIT))) {
            handleSubmit();
        }
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.CANCEL)) && Chat.instance.isChatOpen) {
            Chat.instance.closeChat();
        }
        if (Chat.instance.isChatOpen) {
            handleChatScroll();
        }
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.TOGGLE_CHAT_VISIBILTY)) && !Chat.instance.isChatOpen) {
            Chat.instance.toggleChatVisibility();
        }
    }

    private static void handleSubmit() {
        if (Chat.instance.isChatOpen) {
            Chat.instance.addPlayerChatMessage();
        }
        else {
            Chat.instance.openChat();
        }
    }

    private static void handleChatScroll() {
        if (Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_SCROLL_WHEEL)) > 0) {
            Chat.instance.scrollUp();
        }
        if (Input.GetAxis(KeybindingsFactory.convert(Keybinding.MOUSE_SCROLL_WHEEL)) < 0) {
            Chat.instance.scrollDown();
        }
    }
}
