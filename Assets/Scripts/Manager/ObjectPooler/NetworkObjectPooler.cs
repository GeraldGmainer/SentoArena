using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BeardedManStudios.Network;

[ScriptOrder(-100)]
public abstract class NetworkObjectPooler<T> : SimpleNetworkedMonoBehavior, INetworkObjectPooler where T : NetworkObjectPooler<T> {
    public static T instance;

    private List<GameObject> pooledObjects = new List<GameObject>();

    protected virtual void Awake() {
        instance = this as T;
    }

    protected virtual void Start() {
        for (int i = 0; i < getAmount(); i++) {
            addGameObject(Vector3.down * 1000, Quaternion.identity);
        }
        StartCoroutine("disableAllObjects");
    }

    private GameObject addGameObject(Vector3 position, Quaternion rotation) {
        GameObject go = Instantiate(Resources.Load(getResourcePath()), position, rotation) as GameObject;
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




    public void ShowObject(Vector3 position, Quaternion rotation) {
        Show(position, rotation);
        RPC("RPC_retrieveObject", NetworkReceivers.Others, position, rotation);
    }

    [BRPC]
    public void RPC_retrieveObject(Vector3 position, Quaternion rotation) {
        Show(position, rotation);
    }

    private GameObject Show(Vector3 position, Quaternion rotation) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                pooledObjects[i].SetActive(true);
                pooledObjects[i].transform.position = position;
                pooledObjects[i].transform.rotation = rotation;
                return pooledObjects[i];
            }
        }
        return addGameObject(position, rotation);
    }

    protected override void OnApplicationQuit() {
        instance = null;
    }

    protected abstract int getAmount();
    protected abstract string getResourcePath();
}
