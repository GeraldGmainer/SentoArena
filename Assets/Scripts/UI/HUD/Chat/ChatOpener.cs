using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ChatOpener {
    private Chat chat;
    private InputField inputField;

    public ChatOpener(Chat chat, InputField inputField) {
        this.chat = chat;
        this.inputField = inputField;
    }

    public void open(PlayerController player) {
        chat.isChatOpen = true;
        HUD.instance.showCursor();
        player.inputDisabler.SetInputsFromChat(false);
        inputField.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void close(PlayerController player) {
        chat.isChatOpen = false;
        HUD.instance.hideCursor();
        player.inputDisabler.SetInputsFromChat(false);
        chat.StartCoroutine(hideInputField());
        EventSystem.current.SetSelectedGameObject(null, null);
    }

    IEnumerator hideInputField() {
        yield return new WaitForSeconds(0.1f);
        inputField.gameObject.SetActive(false);
        inputField.text = "";
    }
}
