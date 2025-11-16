using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MenuBase {
    public Text content;
    public Text dots;

    public static LoadingScreen instance;

    protected override void Awake() {
        base.Awake();
        instance = this;
    }

    public void show(string message) {
        MainMenuPlayerManager.instance.hidePlayer();
        mainMenuManager.goToLoadingScreen();
        content.text = message;
        StopCoroutine("updateDots");
        StartCoroutine("updateDots");
    }

    IEnumerator updateDots() {
        while (true) {
            dots.text = getConnectionDots();
            yield return null;
        }
    }

    private string getConnectionDots() {
        string str = "";
        int numberOfDots = Mathf.FloorToInt(Time.timeSinceLevelLoad * 3f % 4);

        for (int i = 0; i < numberOfDots; ++i) {
            str += " .";
        }
        return str;
    }

    public override void onBack() {
    }

}
