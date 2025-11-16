using UnityEngine;
using UnityEngine.UI;

public abstract class SettingInputField : InputField {

    protected override void Start() {
        base.Start();
        onValueChanged.AddListener((string value) => { saveSetting(value); });
        text = Settings.load(getSettingsEnum(), getDefaultValue());
    }

    private void saveSetting(string value) {
        Settings.save(getSettingsEnum(), value);
    }

    protected override void OnEnable() {
        base.OnEnable();
        text = Settings.load(getSettingsEnum(), getDefaultValue());
    }

    public abstract SettingsEnum getSettingsEnum();
    public abstract string getDefaultValue();
}
