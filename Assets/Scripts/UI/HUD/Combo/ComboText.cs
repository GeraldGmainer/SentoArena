using UnityEngine;
using UnityEngine.UI;

public class ComboText : MonoBehaviour {
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void setText(string combo) {
        text.text = combo;
    }

    public void destroy() {
        Destroy(gameObject);
    }
}
