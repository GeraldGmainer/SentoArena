using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingCombatTextMessage : MonoBehaviour {
    private const float MESSAGE_LIVE_TIME = 1;
    private const float FADE_OUT_TIME = 0.5f;

    private Text text;

    void Awake() {
        text = GetComponent<Text>();
    }

    public void setDamageDone(string message, Color color) {
        setMessage(message);
        text.color = color;
    }

    public void setDamageReceived(string message, Color color) {
        setMessage(message);
        text.color = color;
    }

    private void setMessage(string message) {
        text.text = message;
        StartCoroutine(fadeTimer(MESSAGE_LIVE_TIME - FADE_OUT_TIME, FADE_OUT_TIME));
        Destroy(gameObject, MESSAGE_LIVE_TIME);
    }

    IEnumerator fadeTimer(float startFadeOutTime, float fadeOutTime) {
        yield return new WaitForSeconds(startFadeOutTime);
        gameObject.GetComponent<Text>().CrossFadeAlpha(0f, fadeOutTime, false);
    }
}
