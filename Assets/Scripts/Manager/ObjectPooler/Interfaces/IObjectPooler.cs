using UnityEngine;

public interface IObjectPooler {
    GameObject retrieveObject();
    GameObject retrieveObject(Vector3 position);
    GameObject retrieveObject(Vector3 position, Quaternion rotation);
    void disableObject(GameObject go);
}
