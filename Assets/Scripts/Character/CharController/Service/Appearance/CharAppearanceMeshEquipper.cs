using UnityEngine;
using System.Collections.Generic;

public class CharAppearanceMeshEquipper {
    private Transform exportRig;
    private SkinnedMeshRenderer body;

    private Dictionary<GameObject, GameObject> bonesToReparent = new Dictionary<GameObject, GameObject>();

    public void change(CharOutfit outfit) {
        addAppearance(AppearanceFactory.getPath(outfit.hairEnum));
        addAppearance(AppearanceFactory.getPath(outfit.neckEnum));
        addAppearance(AppearanceFactory.getPath(outfit.chestEnum));
        addAppearance(AppearanceFactory.getPath(outfit.glovesEnum));
        addAppearance(AppearanceFactory.getPath(outfit.legsEnum));
        addAppearance(AppearanceFactory.getPath(outfit.bootsEnum));
    }

    private void addAppearance(string path) {
        if (path == null) {
            return;
        }
        GameObject go = Object.Instantiate(Resources.Load(path)) as GameObject;
        CharAppearanceBase appearance = go.GetComponent<CharAppearanceBase>();

        if (appearance.hasCustomRig && appearance.boneAttachments.Count == 0) {
            Debug.LogError("custom rig should have bone attachments");
            return;
        }

        setupGameObject(go);
        if (appearance.hasCustomRig) {
            reparentCustomBones(go, appearance);
        }
        else {
            setupRenderer(go);
        }
        cleanUpAppearance(go, appearance);
    }

    private void reparentCustomBones(GameObject go, CharAppearanceBase appearance) {
        bonesToReparent.Clear();

        foreach (CharAppearanceBoneAttachment boneAttachment in appearance.boneAttachments) {
            GameObject customBone = GameObjectFinder.inChildByName(go.transform, boneAttachment.customBone);
            if (customBone == null) {
                Debug.LogError(appearance.ToString() + " customBone " + boneAttachment.customBone + " not found");
                continue;
            }
            GameObject boneToAttach = GameObjectFinder.inChildByName(exportRig, boneAttachment.boneToAttach);
            if (boneToAttach == null) {
                Debug.LogError(appearance.ToString() + " boneToAttach " + boneAttachment.boneToAttach + " not found");
                continue;
            }
            bonesToReparent.Add(boneToAttach, customBone);
        }

        foreach (KeyValuePair<GameObject, GameObject> entry in bonesToReparent) {
            entry.Value.transform.parent = entry.Key.transform;
            entry.Value.transform.localPosition = Vector3.zero;
            entry.Value.transform.localRotation = Quaternion.identity;
        }
    }

    private void setupGameObject(GameObject go) {
        go.transform.parent = body.transform.parent;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
    }

    private void setupRenderer(GameObject go) {
        SkinnedMeshRenderer renderer = go.GetComponentInChildren<SkinnedMeshRenderer>();
        renderer.bones = body.bones;
        renderer.rootBone = body.rootBone;
        renderer.updateWhenOffscreen = false;
    }

    private static void cleanUpAppearance(GameObject go, CharAppearanceBase appearance) {
        if (!string.IsNullOrEmpty(appearance.objectToRemove)) {
            Object.Destroy(GameObjectFinder.inChildByName(go.transform, appearance.objectToRemove));
        }
    }

    public void SetBody(SkinnedMeshRenderer body) {
        this.body = body;
    }

    public void SetExportRig(Transform exportRig) {
        this.exportRig = exportRig;
    }
}
