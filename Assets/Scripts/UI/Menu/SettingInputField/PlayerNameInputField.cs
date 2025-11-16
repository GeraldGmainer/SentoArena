public class PlayerNameInputField : SettingInputField {

    public override string getDefaultValue() {
        return "Player";
    }

    public override SettingsEnum getSettingsEnum() {
        return SettingsEnum.PLAYER_NAME;
    }
}
