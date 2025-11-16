using UnityEngine;
using System.Collections;

/*
    NOTE:
    cutout texture must be 'Texture Type' = Advanced and 'Read/Write Enabled' = true
*/

public class CharAppearanceCutoutHandler {
    private SkinnedMeshRenderer body;
    private MonoBehaviour controller;

    public CharAppearanceCutoutHandler(MonoBehaviour controller, SkinnedMeshRenderer body) {
        this.controller = controller;
        this.body = body;
    }

    public void handle() {
        controller.StartCoroutine(prepareCutoutCoroutine());
    }

    private IEnumerator prepareCutoutCoroutine() {
        //System.DateTime time = System.DateTime.Now;
        foreach (CharAppearanceBase appearance in controller.transform.GetComponentsInChildren<CharAppearanceBase>()) {
            if (appearance.cutout == null) {
                continue;
            }
            //System.DateTime time2 = System.DateTime.Now;
            Texture2D currentCutout = ((Texture2D)body.material.GetTexture("_CutoutTexture"));
            Texture2D newTexture = appearance.cutout;
            if (currentCutout != null) {
                newTexture = combineTexture(currentCutout, appearance.cutout);
            }
            body.material.SetTexture("_CutoutTexture", newTexture);
            //Debug.Log(appearance.ToString() + " took: " + (System.DateTime.Now - time2));
            yield return null;
        }
        //Debug.Log("Total time: " + (System.DateTime.Now - time));
    }

    private static Texture2D combineTexture(Texture2D firstTexture, Texture2D secondTexture) {
        Texture2D newTexture = new Texture2D(firstTexture.width, firstTexture.height);
        Color[] firstColor = firstTexture.GetPixels();
        Color[] secondColor = secondTexture.GetPixels();
        for (int i = 0; i < firstColor.Length; ++i) {
            firstColor[i] += secondColor[i];
        }
        newTexture.SetPixels(firstColor);
        newTexture.Apply();
        return newTexture;
    }
}
