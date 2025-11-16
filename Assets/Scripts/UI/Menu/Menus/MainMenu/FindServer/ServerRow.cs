using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using BeardedManStudios.Network;
using System.Collections;

public class ServerRow : MonoBehaviour {
    private const float DOUBLE_CLICK_TIME = 0.5f;
    private const string PLAYER_COUNT_TEMPLATE = "{0} / {1}";

    public HostInfo hostInfo { get; private set; }

    private bool isInDoubleClickRange;
    private ValidatorFindServer validatorFindServer;

    public void setup(HostInfo hostInfo, ValidatorFindServer validatorFindServer, UnityAction selectionHandlerAction) {
        this.hostInfo = hostInfo;
        this.validatorFindServer = validatorFindServer;
        updateTexts(hostInfo);
        addClickListener(selectionHandlerAction);  //selectionHandlerAction at first !!
        addClickListener(onClick);
    }

    private void updateTexts(HostInfo hostInfo) {
        Text[] texts = GetComponentsInChildren<Text>();
        texts[0].text = hostInfo.PingTime.ToString();
        texts[1].text = hostInfo.name;
        texts[2].text = hostInfo.sceneName;
        texts[3].text = string.Format(PLAYER_COUNT_TEMPLATE, hostInfo.connectedPlayers, hostInfo.maxPlayers);
        Networking.Ping(hostInfo, onPingReceived);
    }

    private void onPingReceived(HostInfo hostInfo) {
        Debug.Log("PING to " + hostInfo.name + " - " + hostInfo.PingTime + " ms");
        GetComponentsInChildren<Text>()[0].text = hostInfo.PingTime.ToString();
    }

    public void onClick() {
        validatorFindServer.validate();
        if (isInDoubleClickRange && validatorFindServer.isValid) {
            MainMenuNetworkManager.instance.joinServer(hostInfo);
            return;
        }
        StopCoroutine("doubleClickTimer");
        StartCoroutine("doubleClickTimer");
    }

    public string getSceneName() {
        return hostInfo.sceneName;
    }

    IEnumerator doubleClickTimer() {
        isInDoubleClickRange = true;
        yield return new WaitForSeconds(DOUBLE_CLICK_TIME);
        isInDoubleClickRange = false;
    }

    private void addClickListener(UnityAction action) {
        GetComponent<Button>().onClick.AddListener(action);
    }
}
