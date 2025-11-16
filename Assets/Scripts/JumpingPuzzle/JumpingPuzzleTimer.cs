using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class JumpingPuzzleTimer : MonoBehaviour {

    public JumpingPuzzleGoal goal;
    public Text playerTime;
    public Vector3 startPos;
    public Vector3 startRot;

    private float time;

    public static JumpingPuzzleTimer instance;

    void Awake() {
        instance = this;
    }

    public void go() {
        if (time > 0) {
            time = 0;
        }
        StopCoroutine("startTimer");
        StartCoroutine("startTimer");
    }

    public void stop() {
        StopCoroutine("startTimer");
    }

    IEnumerator startTimer() {
        while (true) {
            yield return null;
            time += Time.deltaTime;
            updateUI();
        }
    }

    private void updateUI() {
        TimeSpan t = TimeSpan.FromSeconds(time);
        playerTime.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            reset();
        }
    }

    private void reset() {
        PlayerManager.instance.player.transform.position = startPos;
        PlayerManager.instance.player.transform.rotation = Quaternion.Euler(startRot);
        stop();
        time = 0;
        updateUI();
        goal.reset();
    }

}
