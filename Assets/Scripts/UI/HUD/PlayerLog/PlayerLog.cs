using UnityEngine;

public class PlayerLog : MonoBehaviour {
    private const int MAX_MESSAGES = 3;
    private const string PLAYER_LOG_PATH = "UI/HUD/PlayerLogMessage";
    private static Color errorColor = new Color(1f, 0, 0, 1f);
    private static Color warningColor = new Color(1f, 0.6f, 0, 1f);

    public RectTransform logPanel;

    public static PlayerLog instance;

    void Awake() {
        instance = this;
    }

    public void addErrorMessage(string message) {
        addMessage(message, errorColor);
    }

    public void addWarningMessage(string message) {
        addMessage(message, warningColor);
    }

    private void addMessage(string message, Color messageColor) {
        if (logPanel.transform.childCount >= MAX_MESSAGES) {
            removeFirstMessage();
        }
        createMessage(message, messageColor);
    }

    private void createMessage(string message, Color messageColor) {
        GameObject go = (GameObject)Instantiate(Resources.Load(PLAYER_LOG_PATH));
        go.transform.SetParent(logPanel.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<PlayerLogMessage>().setMessage(message, messageColor);
    }

    private void removeFirstMessage() {
        Destroy(logPanel.transform.GetChild(0).gameObject);
    }
}
