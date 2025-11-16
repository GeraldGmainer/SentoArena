using UnityEngine;
using BeardedManStudios.Network;
using UnityEngine.SceneManagement;

public static class ApplicationManager {
    public static void quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public static void goToScene(MapEnum mapEnum) {
        SceneManager.LoadScene(new MapConverter().convert(mapEnum));
    }

    public static void goToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public static void goToMainMenuScene() {
        SceneManager.LoadScene(MapConverter.MAIN_MENU);
    }

    public static void invokeSceneChanges() {
        if (sceneChangeInvoker != null) {
            sceneChangeInvoker();
        }
        sceneChangeInvoker = null;
    }

    public static bool isInMainMenu() {
        return SceneManager.GetActiveScene().name == MapConverter.MAIN_MENU;
    }

    public static bool isInTestMap() {
        return SceneManager.GetActiveScene().name == MapConverter.TEST_MAP;
    }


    public delegate void SceneChangeEvent();
    public static event SceneChangeEvent sceneChange {
        add {
            sceneChangeInvoker += value;
        }
        remove {
            sceneChangeInvoker -= value;
        }
    }
    static SceneChangeEvent sceneChangeInvoker;
}
