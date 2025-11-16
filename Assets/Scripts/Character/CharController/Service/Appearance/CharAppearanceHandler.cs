using UnityEngine;
using UnityEngine.Rendering;

/*
    a mesh cant have multiple rigs, so we reparent custom rig bones to the orginal rig
*/

public class CharAppearanceHandler {
    private SkinnedMeshRenderer body;
    private CharAppearanceMeshEquipper meshEquipper = new CharAppearanceMeshEquipper();
    private CharAppearanceCutoutHandler cutoutHandler;

    public CharAppearanceHandler(MonoBehaviour controller) {
        body = GameObjectFinder.findBody(controller.transform).GetComponent<SkinnedMeshRenderer>();
        Transform exportRig = GameObjectFinder.findExportRig(controller.transform).transform;

        meshEquipper.SetBody(body);
        meshEquipper.SetExportRig(exportRig);
        cutoutHandler = new CharAppearanceCutoutHandler(controller, body);
    }

    public void Change(CharOutfit outfit) {
        meshEquipper.change(outfit);
        cutoutHandler.handle();
    }

    public void showHair() {
        foreach (Transform child in body.transform.parent) {
            if (child.GetComponent<CharHair>()) {
                child.GetComponentInChildren<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
                if (child.GetComponent<TheNext.PhysicalBoneManager>()) {
                    child.GetComponent<TheNext.PhysicalBoneManager>().enabled = true;
                }
            }
        }
    }

    public void hideHair() {
        foreach (Transform child in body.transform.parent) {
            if (child.GetComponent<CharHair>()) {
                child.GetComponentInChildren<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
                if (child.GetComponent<TheNext.PhysicalBoneManager>()) {
                    child.GetComponent<TheNext.PhysicalBoneManager>().enabled = false;
                }
            }
        }
    }
}
