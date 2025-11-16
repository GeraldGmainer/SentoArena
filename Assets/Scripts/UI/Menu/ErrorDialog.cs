using UnityEngine;
using UnityEngine.UI;

public class ErrorDialog : MonoBehaviour {
    public Text header;
    public Text content;

    public static ErrorDialog instance;

    void Awake() {
        instance = this;
    }

    public void show(string headerText, string contentText) {
        gameObject.SetActive(true);
        gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        header.text = headerText;
        content.text = contentText;
    }

    public void onOK() {
        gameObject.SetActive(false);
    }
}
