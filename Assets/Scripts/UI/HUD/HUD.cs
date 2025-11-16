using UnityEngine;
using UnityEngine.UI;

[ScriptOrder(-2)]
public class HUD : MonoBehaviour {
    public Text fpsText;
    public Slider healthBar;
    public Crosshair crosshair;
    public RectTransform scythe;
    public RectTransform sai;

    private FPSUpdater fpsUpdater;
    private ComboUpdater comboUpdater;
    private CastBarUpdater castBarUpdater;
    private PortBarUpdater portBarUpdater;
    private HUDWeaponUpdater weaponUpdater;
    private CrosshairSpreadHandler crosshairSpreadHandler;
    private CursorLockMode cursorLockMode;
    private bool cursorVisibility;

    public static HUD instance;

    void Awake() {
        instance = this;

        comboUpdater = GetComponent<ComboUpdater>();
        portBarUpdater = GetComponent<PortBarUpdater>();
        castBarUpdater = GetComponent<CastBarUpdater>();

        fpsUpdater = new FPSUpdater(fpsText);
        weaponUpdater = new HUDWeaponUpdater(scythe, sai);
        crosshairSpreadHandler = new CrosshairSpreadHandler(crosshair);
    }

    void Start() {
        if (!Settings.instance.standalone.isStandalone && !PlayerManager.instance.startWithOpenMenu) {
            hideCursor();
        }
    }

    void Update() {
        fpsUpdater.update();
        crosshairSpreadHandler.update();
        Cursor.lockState = cursorLockMode;
        Cursor.visible = cursorVisibility;
    }

    public void hideCursor() {
        cursorVisibility = false;
        cursorLockMode = CursorLockMode.Locked;
    }

    public void showCursor() {
        cursorVisibility = true;
        cursorLockMode = CursorLockMode.None;
    }

    public void showCrosshair() {
        crosshair.gameObject.SetActive(true);
    }

    public void hideCrosshair() {
        crosshair.gameObject.SetActive(false);
    }

    public void setHealth(float value) {
        healthBar.value = value;
    }

    public void startSingleCastBarTimer(float castTime) {
        castBarUpdater.start(castTime, false);
    }

    public void startChargeableCastBarTimer(float castTime) {
        castBarUpdater.start(castTime, true);
    }

    public void stopCastBarTimer() {
        castBarUpdater.stop();
    }

    public void startPortBarTimer(float cooldown) {
        portBarUpdater.start(cooldown);
    }

    public void increaseCrosshairSpread(float spreadIncrease, float maxSpread) {
        crosshairSpreadHandler.increase(spreadIncrease, maxSpread);
    }

    public float getSpreadPixel() {
        return crosshair.getSpreadPixel();
    }

    public void changeWeapon(Weapon weapon) {
        weaponUpdater.change(weapon);
    }

    public void toggleHUDVisibility() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void addCombo(string combo) {
        comboUpdater.addCombo(combo);
    }
}
