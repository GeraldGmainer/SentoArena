using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PortBarUpdater : MonoBehaviour {
    public Slider portBar;

    private float cooldown;

    void Start() {
        updatePortBar(0);
    }

    public void start(float cooldown) {
        this.cooldown = cooldown;
        StopCoroutine("portCDBarTimer");
        StartCoroutine("portCDBarTimer");
    }

    private void stop() {
        StopCoroutine("portCDBarTimer");
        updatePortBar(0);
    }

    IEnumerator portCDBarTimer() {
        float value = cooldown;
        while (value > 0) {
            value = Mathf.Clamp(value - Time.deltaTime, 0, cooldown);
            updatePortBar(value / cooldown);
            yield return null;
        }
        updatePortBar(0);
    }

    private void updatePortBar(float value) {
        portBar.value = value;
    }

}
