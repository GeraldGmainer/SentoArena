using UnityEngine;
using UnityEngine.UI;

public abstract class SettingSlider : Slider {
    protected override void Start() {
        base.Start();
        onValueChanged.AddListener((float val) => { saveSetting(val); });
        value = Settings.load(getSettingsEnum(), getDefaultValue());
    }

    private void saveSetting(float val) {
        Settings.save(getSettingsEnum(), val);
    }

    protected override void OnEnable() {
        base.OnEnable();
        value = Settings.load(getSettingsEnum(), getDefaultValue());
    }

    public abstract SettingsEnum getSettingsEnum();
    public abstract float getDefaultValue();
}
