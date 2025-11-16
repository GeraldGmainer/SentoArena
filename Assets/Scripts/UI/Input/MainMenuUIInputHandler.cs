using UnityEngine;

public class MainMenuUIInputHandler : MonoBehaviour {
    private MainMenuManager mainMenuManager;
    private CreateJoinMenu createJoinMenu;

    void Awake() {
        mainMenuManager = GetComponent<MainMenuManager>();
        createJoinMenu = GetComponentInChildren<CreateJoinMenu>();
    }

    void Update() {
        if (Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.CANCEL))) {
            mainMenuManager.onCancel();
        }

        if (createJoinMenu.gameObject.activeSelf && Input.GetButtonDown(KeybindingsFactory.convert(Keybinding.SUBMIT)) && createJoinMenu.enterButton.interactable) {
            createJoinMenu.enterButton.onClick.Invoke();
        }
    }
}
