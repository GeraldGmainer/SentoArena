using UnityEngine;
using UnityEngine.UI;

public class ButtonTextColorDisabler : MonoBehaviour {
    public Color disableColor = new Color(1, 1, 1, 0.5f);

    private Color startColor;
    private Text theText;
    private Button button;

    void Awake() {
        theText = GetComponent<Text>();
        startColor = theText.color;
        button = transform.parent.GetComponent<Button>();
    }

    void Update() {
        if (button.interactable) {
            theText.color = startColor;
        }
        else {
            theText.color = disableColor;
        }
    }
}
