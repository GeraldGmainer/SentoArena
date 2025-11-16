using UnityEngine;

public class CharRagdollHandler {
    private CharController charController;
    private CharRagdoll ragdoll;
    private Transform ragdollHips;
    private Transform characterHips;

    public CharRagdollHandler(CharController charController) {
        this.charController = charController;
        ragdoll = charController.GetComponentInChildren<CharRagdoll>(true);
        if (ragdoll == null) {
            return;
        }
        ragdollHips = GameObjectFinder.findHips(ragdoll.transform).transform;
        characterHips = GameObjectFinder.findHips(charController.transform).transform;
    }

    public void onDeath(Vector3 spellDamageDirection) {
        ragdoll.gameObject.SetActive(true);
        matchChildren(characterHips.parent, ragdollHips.parent);
        ragdoll.transform.parent = null;
        charController.transform.parent = ragdoll.transform;
        ragdoll.GetComponent<DeadCharacterExplosionForce>().explode(spellDamageDirection);
        SkinnedMeshRenderer body = GameObjectFinder.findBody(charController.transform).GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer ragdollBody = GameObjectFinder.findBody(ragdoll.transform).GetComponent<SkinnedMeshRenderer>();
        ragdollBody.material = body.material;
        //swapCloths(characterBase, go.transform);
        charController.gameObject.SetActive(false);
    }

    public void onRespawn() {
        charController.gameObject.SetActive(true);
        charController.transform.parent = null;
        ragdoll.transform.parent = charController.transform;
        ragdoll.transform.localPosition = Vector3.zero;
        ragdoll.transform.localRotation = Quaternion.identity;
        ragdoll.gameObject.SetActive(false);
    }

    private void matchChildren(Transform source, Transform target) {
        if (source.childCount <= 0) {
            return;
        }

        foreach (Transform sourceTransform in source.transform) {
            Transform targetTransform = target.Find(sourceTransform.name);

            if (targetTransform != null) {
                matchChildren(sourceTransform, targetTransform);
                targetTransform.localPosition = sourceTransform.localPosition;
                targetTransform.localRotation = sourceTransform.localRotation;
            }
        }
    }

    /*
    private static void swapCloths(CharacterBase characterBase, Transform ragdoll) {
        CharacterAppearanceBase[] appearances = characterBase.GetComponentsInChildren<CharacterAppearanceBase>();
        GameObject ragdollBody = GameObjectFinder.findShinoaBody(ragdoll);
        SkinnedMeshRenderer ragollBodyRenderer = ragdollBody.GetComponent<SkinnedMeshRenderer>();
        for (int i = 0; i < appearances.Length; i++) {
            appearances[i].transform.parent = ragdollBody.transform.parent;
            appearances[i].GetComponent<SkinnedMeshRenderer>().bones = ragollBodyRenderer.bones;
        }
        GameObject characterFeet = GameObjectFinder.findShinoaFeet(characterBase.transform);
        if (!characterFeet) {
            GameObjectFinder.findShinoaFeet(ragdoll).SetActive(false);
        }
    }
    */
}
