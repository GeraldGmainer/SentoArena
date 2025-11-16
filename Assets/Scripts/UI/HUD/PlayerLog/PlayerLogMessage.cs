using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLogMessage : MonoBehaviour {
    private const float MESSAGE_LIVE_TIME = 7;
    private const float FADE_OUT_TIME = 2f;

    private Text text;

    private void Awake() {
        text = GetComponent<Text>();
    }

    public void setMessage(string message, Color messageColor) {
        text.text = message;
        text.color = messageColor;
        StartCoroutine(fadeTimer(MESSAGE_LIVE_TIME - FADE_OUT_TIME, FADE_OUT_TIME));
        Destroy(gameObject, MESSAGE_LIVE_TIME);
    }

    IEnumerator fadeTimer(float startFadeOutTime, float fadeOutTime) {
        yield return new WaitForSeconds(startFadeOutTime);
        gameObject.GetComponent<Text>().CrossFadeAlpha(0f, fadeOutTime, false);
    }
}
