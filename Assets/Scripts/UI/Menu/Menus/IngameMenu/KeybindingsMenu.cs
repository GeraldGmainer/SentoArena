using UnityEngine;

public class KeybindingsMenu : MenuBase {

    public override void onBack() {
        base.onBack();
        ingameMenuManager.goToGameMenu();
    }
}
