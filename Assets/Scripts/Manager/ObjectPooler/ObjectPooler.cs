using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ScriptOrder(-100)]
public abstract class ObjectPooler<T> : MonoBehaviour, IObjectPooler where T : ObjectPooler<T> {
    public static T instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    protected virtual void Awake() {
        instance = this as T;
    }

    protected virtual void Start() {
        for (int i = 0; i < getAmount(); i++) {
            addGameObject();
        }
        StartCoroutine("disableAllObjects");
    }

    private GameObject addGameObject() {
        GameObject go = Instantiate(Resources.Load(getResourcePath()), Vector3.down * 1000, Quaternion.identity) as GameObject;
        go.transform.parent = transform;
        pooledObjects.Add(go);
        return go;
    }

    IEnumerator disableAllObjects() {
        yield return null;
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (pooledObjects[i].transform.parent.GetInstanceID() == transform.GetInstanceID()) {
                pooledObjects[i].SetActive(false);
            }
        }
    }

    public GameObject retrieveObject(Vector3 position) {
        GameObject go = retrieveObject();
        go.transform.position = position;
        return go;
    }

    public GameObject retrieveObject(Vector3 position, Quaternion rotation) {
        GameObject go = retrieveObject();
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }

    public GameObject retrieveObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        //if (Time.frameCount > 2) {
        //    Debug.Log(GetType().Name + " created new object");
        //}
        return addGameObject();
    }

    void OnApplicationQuit() {
        instance = null;
    }

    public void disableObject(GameObject go) {
        go.transform.parent = transform;
        go.SetActive(false);
    }

    protected abstract int getAmount();
    protected abstract string getResourcePath();
}
