using UnityEngine;

[ScriptOrder(-200)]
public class Settings : MonoBehaviour {
    private const string KEY_PREFIX = "Setting";

    public static Settings instance;

    void Awake() {
        instance = this;
        new StandaloneFileReader(this).read();
    }

    public CharSettings charSettings;
    public CharMovementSettings charMovement;
    public CameraSettings cameraSettings;

    [Header("Spells")]
    public BlackFireballLightSettings blackFireballLight;
    public BlackFireballHardSettings blackFireballHard;
    public BlackFireballHardComboSettings blackFireballHardCombo;
    public BlackFireballChargeSettings blackFireballCharge;
    public BlackFireballTaidenSettings blackFireballTaiden;
    public BlackFireballPortSettings blackFireballPort;

    public LightningLightSettings lightningLight;
    public LightningHardSettings lightningHard;
    public LightningPortSettings lightningPort;

    [HideInInspector]
    public StandaloneModel standalone;

    public static void save(SettingsEnum settingsEnum, float value) {
        PlayerPrefs.SetFloat(generateKey(settingsEnum), value);
    }

    public static void save(SettingsEnum settingsEnum, int value) {
        PlayerPrefs.SetInt(generateKey(settingsEnum), value);
    }

    public static void save(SettingsEnum settingsEnum, string value) {
        PlayerPrefs.SetString(generateKey(settingsEnum), value);
    }

    public static void save(SettingsEnum settingsEnum, bool value) {
        PlayerPrefs.SetInt(generateKey(settingsEnum), (value ? 1 : 0));
    }

    public static float load(SettingsEnum settingsEnum, float defaultValue) {
        return PlayerPrefs.GetFloat(generateKey(settingsEnum), defaultValue);
    }

    public static int load(SettingsEnum settingsEnum, int defaultValue) {
        return PlayerPrefs.GetInt(generateKey(settingsEnum), defaultValue);
    }

    public static string load(SettingsEnum settingsEnum, string defaultValue) {
        return PlayerPrefs.GetString(generateKey(settingsEnum), defaultValue);
    }

    public static bool load(SettingsEnum settingsEnum, bool defaultValue) {
        return PlayerPrefs.GetInt(generateKey(settingsEnum), (defaultValue ? 1 : 0)) == 1 ? true : false;
    }

    private static string generateKey(SettingsEnum settingsEnum) {
        return KEY_PREFIX + settingsEnum.ToString();
    }
}
