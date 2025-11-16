using UnityEngine;
using UnityEngine.EventSystems;
using BeardedManStudios.Network;

public static class GameObjectFinder {
    public static GameObject inChildByName(Transform trans, string withName) {
        return inChildByName(trans, withName, false);
    }

    public static GameObject inChildByNameIncludeInactive(Transform trans, string withName) {
        return inChildByName(trans, withName, true);
    }

    private static GameObject inChildByName(Transform trans, string withName, bool includeInactive) {
        Transform[] ts = trans.GetComponentsInChildren<Transform>(includeInactive);
        foreach (Transform t in ts) {
            if (t.gameObject.name.Contains(withName)) {
                return t.gameObject;
            }
        }
        return null;
    }

    public static Camera findMainCamera() {
        return GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<Camera>();
    }

    public static EventSystem findEventSystem() {
        return GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public static GameObject findPlayer() {
        return GameObject.FindGameObjectWithTag(Tags.Player);
    }

    public static GameObject findBody(Transform transform) {
        return inChildByName(transform, "FemaleBody");
    }

    public static GameObject findTPSBone(Transform transform) {
        return inChildByName(transform, "TPSBone");
    }

    public static GameObject findHips(Transform transform) {
        return inChildByName(transform, "hips");
    }

    public static GameObject findSwordBoneLeft(Transform transform) {
        return inChildByName(transform, "swordBone_L");
    }

    public static GameObject findSwordBoneRight(Transform transform) {
        return inChildByName(transform, "swordBone_R");
    }

    public static GameObject findExportRig(Transform transform) {
        return inChildByName(transform, "ExportRig");
    }

    public static Vector3 findLightningSpawnPosition(Transform transform) {
        Transform left = inChildByName(findSwordBoneLeft(transform).transform, "LightningSpawnPosition").transform;
        Transform right = inChildByName(findSwordBoneRight(transform).transform, "LightningSpawnPosition").transform;
        return (left.position + right.position) / 2;
    }

    public static Transform findPlayerWithOwnerId(ulong ownerId) {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(Tags.Player)) {
            if (go.GetComponent<SimpleNetworkedMonoBehavior>() == null) {
                Debug.LogError("Player has no SimpleNetworkedMonoBehavior. UNITY BUG?! restart ?!?!");
                return null;
            }
            if (go.GetComponent<SimpleNetworkedMonoBehavior>().OwnerId == ownerId) {
                return go.transform;
            }
        }
        Debug.LogError("player with ownerId not found");
        return null;
    }
}
