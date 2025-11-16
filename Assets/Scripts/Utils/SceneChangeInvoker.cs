using UnityEngine;

public class SceneChangeInvoker : MonoBehaviour {

    void OnLevelWasLoaded(int level) {
        ApplicationManager.invokeSceneChanges();
    }
}
