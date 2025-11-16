using UnityEngine;
using System;
using System.Text;

public class StandaloneFileReader {
    private const string PATH = "standalone.ini";

    private string[] lines;
    private Settings settings;

    public StandaloneFileReader(Settings settings) {
        this.settings = settings;
    }

    public void read() {
        if (!FileUtilities.FileExists(PATH)) {
            return;
        }
        readFromFile();
        settings.standalone.isStandalone = readBooleanSetting("STANDALONE");
        settings.standalone.port = readIntSetting("PORT");
        settings.standalone.sceneName = readStringSetting("SCENE_NAME");
        settings.standalone.maxPlayer = readIntSetting("MAX_PLAYER");
        settings.standalone.serverName = readStringSetting("SERVER_NAME");
        settings.standalone.masterServerIP = readStringSetting("MASTER_SERVER");
    }


    private void readFromFile() {
        string settingLines = Encoding.Default.GetString(FileUtilities.ReadFile(PATH));
        lines = settingLines.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
    }

    private bool readBooleanSetting(string keyName) {
        return "true".Equals(readStringSetting(keyName)) ? true : false;
    }

    private int readIntSetting(string keyName) {
        return int.Parse(readStringSetting(keyName));
    }

    private string readStringSetting(string keyName) {
        foreach (string line in lines) {
            string[] lineSplit = line.Split(new string[] { "=" }, StringSplitOptions.None);
            string key = lineSplit[0].Trim().ToUpper();
            string value = lineSplit[1].Trim();
            if (keyName.ToUpper().Equals(key)) {
                return value;
            }
        }
        Debug.LogError(" required Setting " + keyName + " not found");
        return "";
    }

}
