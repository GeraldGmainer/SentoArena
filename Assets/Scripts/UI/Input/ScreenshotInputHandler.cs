using UnityEngine;

public class ScreenshotInputHandler : MonoBehaviour {
    public KeyCode key = KeyCode.T;

    void Update() {
        if (Input.GetKeyDown(key)) {
            Application.CaptureScreenshot("Screenshot.png", 4);
        }
    }
}
