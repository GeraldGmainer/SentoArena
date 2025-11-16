using UnityEngine;
using Zenject;

public class ZenGameObjectService {

    public GameObject inChildByName(Transform transform, string withName) {
        return inChildByName(transform, withName, false);
    }

    public GameObject inChildByName(Transform transform, string withName, bool includeInactive) {
        Transform[] ts = transform.GetComponentsInChildren<Transform>(includeInactive);
        foreach (Transform t in ts) {
            if (t.gameObject.name.Contains(withName)) {
                return t.gameObject;
            }
        }
        return null;
    }
}
