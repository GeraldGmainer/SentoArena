using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BeardedManStudios.Network;

public class ServerListSelectionHandler : MonoBehaviour {
    public MapPreview mapPreview;

    private Color selectionColor = new Color(230, 230, 230, 0.4f);
    private Color normalColor = new Color(230, 230, 230, 0f);

    private ServerRow oldServerRow;
    private ServerRow selectedServerRow;
    private EventSystem eventSystem;
    private MapConverter mapConverter;

    void Awake() {
        mapConverter = new MapConverter();
        eventSystem = GameObjectFinder.findEventSystem();
    }

    public void onClick(ServerRow serverRow) {
        resetSelectedGameObjectBecauseInputHandlerShouldHandleSubmit();
        if (oldServerRow != null) {
            oldServerRow.GetComponent<Image>().color = normalColor;
        }

        selectedServerRow = serverRow;
        serverRow.GetComponent<Image>().color = selectionColor;
        serverRow.GetComponent<Image>().enabled = true;
        oldServerRow = serverRow;
        mapPreview.changeTo(mapConverter.convert(serverRow.getSceneName()));
    }

    private void resetSelectedGameObjectBecauseInputHandlerShouldHandleSubmit() {
        eventSystem.SetSelectedGameObject(null);
    }

    public void reset() {
        selectedServerRow = null;
    }

    void OnEnable() {
        reset();
    }

    public bool isAnyServerSelected() {
        return selectedServerRow != null;
    }

    public HostInfo getSelectedHostInfo() {
        return selectedServerRow.hostInfo;
    }
}
