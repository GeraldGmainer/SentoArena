using UnityEngine;

public class PortGravityHandler {
    private CharGravity charGravity;
    private int layerMask = (1 << Layers.DEFAULT);

    public PortGravityHandler(Transform transform) {
        charGravity = transform.GetComponentInChildren<CharGravity>();
    }

    public void handle(PortResult portResult) {
        RaycastHit hit;
        Debug.DrawRay(portResult.target - portResult.groundDirection * 0.1f, portResult.groundDirection * 0.3f, Color.black, 5f);
        if (Physics.Raycast(portResult.target - portResult.groundDirection * 0.1f, portResult.groundDirection, out hit, 0.3f, layerMask)) {
            GravityObject gravityObject = hit.transform.GetComponentInChildren<GravityObject>();
            charGravity.changeGravityObjectFromPort(gravityObject);
        }
    }
}
