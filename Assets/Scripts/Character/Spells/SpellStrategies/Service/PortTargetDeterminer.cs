using UnityEngine;

public class PortTargetDeterminer {
    private float capsuleRadius = 0.25f;
    private float capsuleHeight = 1.7f;
    private float playerCenterHeight = 1f;
    private int layerMask = (1 << Layers.DEFAULT);

    private Vector3 startPosition;
    private PortResult portResult;
    private Transform transform;
    private IPortSettings portSettings;

    public PortTargetDeterminer(Transform transform) {
        this.transform = transform;
    }

    public PortResult determine(IPortSettings portSettings) {
        this.portSettings = portSettings;
        portResult = new PortResult();

        determinePositionWithoutRays();
        respectObstacleInFront();
        determineGroundPosition();

        //Debug.DrawLine(targetPosition + new Vector3(0, 0.1f, 0), targetPosition + new Vector3(0, 0.1f, 0) + Vector3.up * capsuleHeight, Color.red, 5);
        if (isTargetPositionHeightTooSmall()) {
            portResult.isValid = false;
            portResult.errorMessage = "The port-target area is not high enough";
            return portResult;
        }

        if (isTargetPositionDistanceTooSmall()) {
            portResult.isValid = false;
            portResult.errorMessage = "The port-target is too close";
            return portResult;
        }

        if (isPositionDistanceValid(portResult.target, 1f)) {
            return portResult;
        }

        tryToTeleportOnObjectsWithStairsTag();
        return portResult;
    }



    private void determinePositionWithoutRays() {
        startPosition = transform.position + transform.TransformDirection(new Vector3(0, playerCenterHeight, 0));
        portResult.target = startPosition + transform.forward * portSettings.MaxRange;

        //Debug.DrawLine(startPosition, portResult.target, Color.black, 5);
    }

    private void respectObstacleInFront() {
        RaycastHit hit;
        if (Physics.Linecast(startPosition, portResult.target, out hit, layerMask)) {
            portResult.target = startPosition + transform.forward * (hit.distance - capsuleRadius);
        }
    }

    private Vector3 determineGravityDirection() {
        RaycastHit hit;
        Vector3 direction = (portResult.target - startPosition).normalized;
        //Debug.DrawRay(startPosition, direction * Settings.instance.port.distance, Color.black, 5);
        if (Physics.Raycast(startPosition, direction, out hit, portSettings.MaxRange, layerMask)) {
            GravityObject gravityObject = hit.transform.GetComponentInChildren<GravityObject>();
            if (gravityObject != null) {
                return gravityObject.determineDirection(portResult.target);
            }
        }
        return Vector3.zero;
    }

    private void determineGroundPosition() {
        Vector3 gravityDirection = determineGravityDirection();
        if (gravityDirection != Vector3.zero) {
            if (!groundRay(gravityDirection)) {
                if (!groundRay(transform.up)) {
                    groundRay(Vector3.up);
                }
            }
        }
        else {
            if (!groundRay(transform.up)) {
                groundRay(Vector3.up);
            }
        }
    }

    private bool groundRay(Vector3 direction) {
        RaycastHit hit;
        //Debug.DrawRay(portResult.target, -direction * 100, Color.magenta, 5);
        if (Physics.Raycast(portResult.target, -direction * 100, out hit, 100, layerMask)) {
            portResult.groundDirection = (hit.point - portResult.target).normalized;
            portResult.target = hit.point; //- portResult.groundDirection * 0.05f;
            return true;
        }
        return false;
    }

    private bool isTargetPositionHeightTooSmall() {
        RaycastHit hit;
        Vector3 groundStart = portResult.target - portResult.groundDirection * 0.05f;
        float length = capsuleHeight + 0.05f;
        //Debug.DrawRay(groundStart, -portResult.groundDirection * length, Color.black, 5);
        return Physics.Raycast(groundStart, -portResult.groundDirection, out hit, length, layerMask);
    }

    private bool isTargetPositionDistanceTooSmall() {
        return Vector3.Distance(startPosition, portResult.target) < portSettings.MinDistance;
    }

    private bool isPositionDistanceValid(Vector3 target, float spazi) {
        return Vector3.Distance(transform.position, target) > portSettings.MaxRange - spazi;
    }

    private void tryToTeleportOnObjectsWithStairsTag() {
        Vector3 start = startPosition;
        Vector3 end = portResult.target;

        for (int i = 0; !isPositionDistanceValid(portResult.target, 0) || i < 30; i++) {
            start += new Vector3(0, 0.3f, 0);
            end += new Vector3(0, 0.3f, 0) + extendPositionToDistance();

            //Debug.DrawLine(start, end, Color.black, 5);
            RaycastHit hit;
            if (Physics.Linecast(start, end, out hit, layerMask)) {
                if (hit.transform.tag != "Stairs" || isPositionDistanceValid(hit.point, 0)) {
                    break;
                }
                portResult.target = hit.point;
            }
            else {
                break;
            }
        }
    }

    private Vector3 extendPositionToDistance() {
        return transform.forward * (portSettings.MaxRange - Vector3.Distance(transform.position, portResult.target));
    }
}
