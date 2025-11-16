using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatMessageAdder {
    private const string PLAYER_MESSAGE_FORMAT = "[{0}]";
    private const string CHAT_MESSAGE_PREFAB_NAME = "ChatMessage";

    private Chat chat;
    private ScrollRect scrollRect;
    private RectTransform chatContent;
    private ChatMessageStyler chatMessageStyler;
    private ChatCommandHandler chatCommandHandler;

    public ChatMessageAdder(Chat chat, RectTransform chatContent, ScrollRect scrollRect) {
        this.chat = chat;
        this.scrollRect = scrollRect;
        this.chatContent = chatContent;
        chatMessageStyler = new ChatMessageStyler();
        chatCommandHandler = new ChatCommandHandler();
    }

    public void addPlayerMessage(CharController player, string message) {
        string trimmedMessage = message.Trim();
        if (trimmedMessage.Length == 0) {
            return;
        }
        if (chatCommandHandler.check(trimmedMessage)) {
            return;
        }
        string playerName = string.Format(PLAYER_MESSAGE_FORMAT, player.charName);
        addMessage(playerName + " " + trimmedMessage, ChatMessageType.PLAYER);
    }

    public void addSystemMessage(string message, ChatMessageType chatMessageType) {
        addMessage(message, chatMessageType);
    }

    private void addMessage(string message, ChatMessageType chatMessageType) {
        GameObject go = GameObject.Instantiate(Resources.Load(CHAT_MESSAGE_PREFAB_NAME), Vector3.zero, Quaternion.identity) as GameObject;
        ChatMessage chatMessage = go.GetComponent<ChatMessage>();
        chatMessage.setMessage(message);
        chatMessageStyler.style(chatMessageType, chatMessage);
        go.GetComponent<RectTransform>().SetParent(chatContent);
        chat.StartCoroutine(scrollToBottom());
    }

    IEnumerator scrollToBottom() {
        yield return new WaitForSeconds(0.1f);
        scrollRect.verticalNormalizedPosition = 0;
    }
}
