public class MouseSensitivitySlider : SettingSlider {

    public override SettingsEnum getSettingsEnum() {
        return SettingsEnum.MOUSE_SENSITIVITY;
    }

    public override float getDefaultValue() {
        return 8;
    }
}
