using UnityEngine;

public class JumpingPuzzleStart : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        JumpingPuzzleTimer.instance.go();
    }
}
