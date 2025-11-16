using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CastBarUpdater : MonoBehaviour {
    private const float SPAZI = 0.05f;

    public Slider castBar;

    private float castTime;
    private bool isChargeSpell;

    void Start() {
        updateCastBar(0);
    }

    public void start(float castTime, bool isChargeSpell) {
        this.castTime = castTime;
        this.isChargeSpell = isChargeSpell;
        StopCoroutine("castBarUpdateTimer");
        StartCoroutine("castBarUpdateTimer");
    }

    public void stop() {
        StopCoroutine("castBarUpdateTimer");
        updateCastBar(0);
    }

    IEnumerator castBarUpdateTimer() {
        float time = 0;
        while (time < castTime + SPAZI) {
            if (PlayerManager.instance.isPlayerDead()) {
                stop();
                yield break;
            }
            updateCastBar(time / (castTime + SPAZI));
            yield return null;
            time += Time.deltaTime;
        }
        updateCastBar(isChargeSpell ? 1 : 0);
    }

    private void updateCastBar(float value) {
        castBar.value = value;
        castBar.gameObject.SetActive(value > 0.01);
    }
}
