public class ChatMessageStyler {
    public void style(ChatMessageType chatMessageType, ChatMessage chatMessage) {

        switch (chatMessageType) {
            case ChatMessageType.SYSTEM_ITALIC:
            italic(chatMessage);
            grayFont(chatMessage);
            break;

            case ChatMessageType.PLAYER:
            case ChatMessageType.SYSTEM:
            break;
        }
    }

    private void italic(ChatMessage chatMessage) {
        chatMessage.GetComponent<ChatMessage>().setMessageItalic();
    }

    private static void grayFont(ChatMessage chatMessage) {
        chatMessage.GetComponent<ChatMessage>().setGrayFont();
    }
}
