public class ServerNameInputField : SettingInputField {

    public override SettingsEnum getSettingsEnum() {
        return SettingsEnum.SERVER_NAME;
    }

    public override string getDefaultValue() {
        return "ServerName";
    }
}
