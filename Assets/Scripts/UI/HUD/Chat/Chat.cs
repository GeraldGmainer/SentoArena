using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {
    private const float SCROLL_SENSITIVITY = 15;

    public bool defaultChatVisibility = false;

    [SerializeField]
    private RectTransform chatLayoutGroup;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private RectTransform chatContent;
    [SerializeField]
    private ScrollRect scrollRect;

    public bool isChatOpen { get; set; }

    private ChatOpener chatOpener;
    private ChatMessageAdder chatMessageAdder;

    public static Chat instance;

    void Awake() {
        instance = this;
        chatOpener = new ChatOpener(this, inputField);
        chatMessageAdder = new ChatMessageAdder(this, chatContent, scrollRect);
    }

    void Start() {
        chatLayoutGroup.gameObject.SetActive(defaultChatVisibility);
        addSystemItalicMessage("available commands:");
        addSystemItalicMessage("bot_add");
        addSystemItalicMessage("bot_kick");
    }

    public void openChat() {
        chatLayoutGroup.gameObject.SetActive(true);
        chatOpener.open(PlayerManager.instance.player);
    }

    public void closeChat() {
        chatOpener.close(PlayerManager.instance.player);
    }

    public void addSystemMessage(string text) {
        chatMessageAdder.addSystemMessage(text, ChatMessageType.SYSTEM);
    }

    public void addSystemItalicMessage(string text) {
        chatMessageAdder.addSystemMessage(text, ChatMessageType.SYSTEM_ITALIC);
    }

    public void addPlayerChatMessage() {
        chatMessageAdder.addPlayerMessage(PlayerManager.instance.player, inputField.text);
        closeChat();
    }

    public void scrollUp() {
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + getScrollStep());
    }

    public void scrollDown() {
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition - getScrollStep());
    }

    private float getScrollStep() {
        return scrollRect.gameObject.GetComponent<RectTransform>().rect.height / scrollRect.content.rect.height * SCROLL_SENSITIVITY / 100;
    }

    public void toggleChatVisibility() {
        chatLayoutGroup.gameObject.SetActive(!chatLayoutGroup.gameObject.activeSelf);
    }
}

