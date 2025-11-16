using UnityEngine;

public class ComboListMenu : MenuBase {

    public override void onBack() {
        base.onBack();
        ingameMenuManager.goToGameMenu();
    }
}
