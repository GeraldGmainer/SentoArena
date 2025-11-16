using UnityEngine;
using BeardedManStudios.Network;

public abstract class MenuManagerBase : MonoBehaviour {
    protected MenuBase currentMenu;

    public void quit() {
        if (NetworkingManager.IsOnline) {
            Networking.Disconnect();
        }
        ApplicationManager.quit();
    }

    public void goToMainMenuScene() {
        if (NetworkingManager.IsOnline) {
            Networking.Disconnect();
        }
        Networking.NetworkingReset();
        ApplicationManager.goToMainMenuScene();
    }

    public virtual void onCancel() {
        if (currentMenu != null) {
            currentMenu.onBack();
        }
    }

    protected void changeMenu(MenuBase menuBase) {
        if (currentMenu) {
            currentMenu.onHide();
        }
        currentMenu = menuBase;
        currentMenu.onShow();
    }
}
