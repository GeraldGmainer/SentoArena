using UnityEngine;
using UnityEngine.UI;
using BeardedManStudios.Network;

public class TestsceneHUD : MonoBehaviour {
    public Text isServerText;
    public Text portedDistanceText;
    public Text speedText;
    public Text horSpeedText;
    public Text vertSpeedText;
    public Text inAirText;
    public Text bytesInText;
    public Text bytesOutText;

    public static TestsceneHUD instance;

    void Awake() {
        instance = this;
    }

    void Update() {
        if (Networking.PrimarySocket != null && Networking.PrimarySocket.TrackBandwidth) {
            bytesInText.text = NetWorker.BandwidthIn.ToString();
            bytesOutText.text = NetWorker.BandwidthOut.ToString();
        }
        if (NetworkingManager.IsOnline) {
            isServerText.text = NetworkingManager.Instance.IsServerOwner ? "YES" : "NO";
        }
    }

    public void setPortedDistance(float distance) {
        portedDistanceText.text = distance.ToString("0.00");
    }

    public void setSpeed(float speed) {
        speedText.text = speed.ToString("0.00");
    }

    public void setHorSpeed(float speed) {
        horSpeedText.text = speed.ToString("0.00");
    }

    public void setVertSpeed(float speed) {
        vertSpeedText.text = speed.ToString("0.00");
    }

    public void setInAir(bool inAir) {
        inAirText.text = inAir ? "Yes" : "No";
    }
}
