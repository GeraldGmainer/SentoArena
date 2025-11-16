public class GameMenu : MenuBase {

    public void onReturnToGame() {
        onBack();
    }

    public override void onShow() {
        base.onShow();
        ingameMenuManager.open();
        HUD.instance.showCursor();
        HUD.instance.hideCrosshair();
        PlayerManager.instance.player.inputDisabler.SetInputsFromInMenu(false);
    }

    public override void onBack() {
        base.onBack();
        ingameMenuManager.close();
        HUD.instance.hideCursor();
        HUD.instance.showCrosshair();
        PlayerManager.instance.player.inputDisabler.SetInputsFromInMenu(true);
    }
}
