using UnityEngine;
using System.Collections;

public class MainMenu : MenuBase {

    protected override void Awake() {
        base.Awake();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void onBack() {
    }

    public override void onShow() {
        base.onShow();
        MainMenuPlayerManager.instance.hidePlayer();
    }
}
