using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharGravity : MonoBehaviour {
    private const float LERP_SPEED = 1.5f;
    private const float MAX_GRAVITY_CHANGE_TIME = 0.5f;

    public float JumpMultiplier { get; private set; }
    public float gravityDelayMultiplier { get; private set; }
    public Vector3 gravityDirection { get { return currentGravity == null ? Vector3.up : currentGravity.determineDirection(transform.position); } }

    private GravityObject currentGravity;

    private bool canChangeGravity;
    private bool isPorting;
    private float lastGravityChange;
    private CharActorDriver actorDriver;
    private CharNetworkController networkController;
    private List<GravityObject> gravityObjects = new List<GravityObject>();

    void Awake() {
        actorDriver = transform.parent.GetComponent<CharActorDriver>();
        networkController = transform.parent.GetComponent<CharNetworkController>();
    }

    void Start() {
        JumpMultiplier = 1;
        canChangeGravity = true;
    }

    void Update() {
        if (networkController.isNotOwner()) {
            return;
        }
        if (actorDriver.IsGrounded) {
            canChangeGravity = true;
            stopGravityDelayTimer();
            return;
        }

        if (gravityObjects.Count <= 0 || !canChangeGravity || Time.time - lastGravityChange < MAX_GRAVITY_CHANGE_TIME || !actorDriver.isGravityEnabled) {
            return;
        }
        changeGravityObjectByDistance();
    }

    private void changeGravityObjectByDistance() {
        gravityObjects.Sort(distanceComperator());

        foreach (GravityObject gravityObject in gravityObjects) {
            if (gravityObject != currentGravity) {
                changeGravityObject(gravityObject);
                break;
            }
        }
    }

    private Comparison<GravityObject> distanceComperator() {
        return delegate (GravityObject a, GravityObject b) {
            var dstToA = Vector3.Distance(transform.position, a.transform.position);
            var dstToB = Vector3.Distance(transform.position, b.transform.position);
            return dstToA.CompareTo(dstToB);
        };
    }

    public void reset() {
        currentGravity = null;
        gravityObjects = new List<GravityObject>();
    }

    public void changeGravityObjectFromPort(GravityObject gravityObject) {
        actorDriver.StartOrientToGroundPortPause();
        if (gravityObject == currentGravity) {
            return;
        }
        changeGravityObject(gravityObject);
    }

    private void changeGravityObject(GravityObject gravityObject) {
        if (gravityObject == currentGravity) {
            return;
        }
        if (gravityObject != null) {
            startGravityDelayTimer();
        }
        lastGravityChange = Time.time;
        currentGravity = gravityObject;
        canChangeGravity = false;
        Debug.Log("change TO " + (gravityObject == null ? "null" : gravityObject.transform.parent.name));
    }

    public bool isGravityRelative() {
        return currentGravity != null;
    }





    void OnTriggerEnter(Collider collider) {
        registerGravityObject(collider);
        registerJumpMultiplier(collider);
    }

    void OnTriggerExit(Collider collider) {
        unregisterGravityObject(collider);
        unregisterJumpMultiplier(collider);
    }

    private void registerGravityObject(Collider collider) {
        if (collider.GetComponent<GravityObject>()) {
            stopResetGravityObjecTimer();
            gravityObjects.Add(collider.GetComponent<GravityObject>());
        }
    }

    private void unregisterGravityObject(Collider collider) {
        if (collider.GetComponent<GravityObject>()) {
            gravityObjects.Remove(collider.GetComponent<GravityObject>());
            if (gravityObjects.Count <= 0 && currentGravity != null) {
                startResetGravityObjectTimer();
            }
        }
    }

    private void registerJumpMultiplier(Collider collider) {
        if (collider.GetComponent<ExtraJumpHeightArea>()) {
            JumpMultiplier = collider.GetComponent<ExtraJumpHeightArea>().jumpMultiplier;
        }
    }

    private void unregisterJumpMultiplier(Collider collider) {
        if (collider.GetComponent<ExtraJumpHeightArea>()) {
            JumpMultiplier = 1;
        }
    }




    /*
    leave gravity object after a certain amount of time
    */

    private void startResetGravityObjectTimer() {
        stopResetGravityObjecTimer();
        StartCoroutine("resetGravityObjectTimer");
    }

    private void stopResetGravityObjecTimer() {
        StopCoroutine("resetGravityObjectTimer");
    }

    IEnumerator resetGravityObjectTimer() {
        yield return new WaitForSeconds(1f);
        StopCoroutine("gravityDelayTimer");
        changeGravityObject(null);
        canChangeGravity = true;
    }




    /*
    avoid infinite orbiting around planet (only on gravity change)
    */

    private void startGravityDelayTimer() {
        stopGravityDelayTimer();
        StartCoroutine("gravityDelayTimer");
    }

    private void stopGravityDelayTimer() {
        gravityDelayMultiplier = 1;
        StopCoroutine("gravityDelayTimer");
    }

    IEnumerator gravityDelayTimer() {
        yield return new WaitForSeconds(3f);
        Debug.Log("Start gravity correction");
        //canChangeGravity = true;
        while (gravityDelayMultiplier < 10) {
            gravityDelayMultiplier += Time.deltaTime * 5;
            yield return null;
        }
    }
}
