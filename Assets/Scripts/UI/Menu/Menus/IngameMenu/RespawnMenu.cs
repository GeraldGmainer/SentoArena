using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RespawnMenu : MenuBase {
    private const string RESPAWN_CLICKLABLE_TEXT = "Respawn";
    private const string RESPAWN_WAIT_TEMPLATE = "Respawn ({0})";

    public Button respawnButton;

    private Text respawnText;

    protected override void Awake() {
        base.Awake();
        respawnText = respawnButton.GetComponentInChildren<Text>();
    }

    public void onRespawn() {
        PlayerManager.instance.respawnPlayer();
        hideMenu();
        HUD.instance.showCrosshair();
        HUD.instance.hideCursor();
        ingameMenuManager.close();
    }

    public override void onShow() {
        base.onShow();
        HUD.instance.hideCrosshair();
        HUD.instance.showCursor();
        StartCoroutine("respawnWaitTimer");
    }

    IEnumerator respawnWaitTimer() {
        respawnButton.interactable = false;
        for (int i = Settings.instance.charSettings.RespawnWaitTime; i >= 1; i--) {
            respawnText.text = string.Format(RESPAWN_WAIT_TEMPLATE, i);
            yield return new WaitForSeconds(1);
        }
        respawnButton.interactable = true;
        respawnText.text = RESPAWN_CLICKLABLE_TEXT;
    }

    public override void onBack() {
    }
}
