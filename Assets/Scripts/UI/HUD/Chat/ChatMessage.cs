using UnityEngine;
using UnityEngine.UI;
using System;

public class ChatMessage : MonoBehaviour {
    private static string TIMESTAP_FORMAT = "[{0}]";
    private static string MESSAGE_FORMAT = "                    {0}";

    private Text timestamp;
    private Text message;

    void Awake() {
        timestamp = GetComponentsInChildren<Text>()[0];
        message = GetComponentsInChildren<Text>()[1];
    }

    public void setMessage(string text) {
        updateTimestamp();
        updateMessage(text);
        resizeMessage();
    }

    private void updateTimestamp() {
        DateTime dt = DateTime.Now;
        timestamp.text = string.Format(TIMESTAP_FORMAT, dt.ToString("HH:mm:ss"));
    }

    private void updateMessage(string text) {
        message.text = string.Format(MESSAGE_FORMAT, text);
    }

    private void resizeMessage() {
        GetComponent<LayoutElement>().preferredHeight = message.preferredHeight;
        GetComponent<LayoutElement>().minHeight = message.preferredHeight;
    }

    public void setMessageItalic() {
        message.fontStyle = FontStyle.Italic;
    }

    public void setGrayFont() {
        message.color = new Color(0.9f, 0.9f, 0.9f);
    }
}
