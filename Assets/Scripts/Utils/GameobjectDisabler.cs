using UnityEngine;
using System.Collections;

public class GameobjectDisabler : MonoBehaviour {
    public float disableTime = 2f;

    void OnEnable() {
        StopCoroutine("disableTimer");
        StartCoroutine("disableTimer");
    }

    void OnDisable() {
        StopCoroutine("disableTimer");
    }

    IEnumerator disableTimer() {
        yield return new WaitForSeconds(disableTime);
        gameObject.SetActive(false);
    }

}
