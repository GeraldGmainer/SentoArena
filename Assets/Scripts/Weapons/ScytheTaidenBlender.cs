using UnityEngine;

public class ScytheTaidenBlender : MonoBehaviour {
    //private static int NORMAL_SCYTHE_WEIGHT = 0;
    //private static int DOUBLE_SCYTHE_WEIGHT = 1;

    //public float BlendDelay = 0.8f;
    //public float BlendTime = 0.2f;
    //public float BlendBackDelay = 0.5f;

    //private bool blendBack;
    //private float delayTimer;
    //private float blendTimer;
    //private float blendBlackTimer;
    //private float blendWeight;
    //private GameObject scythe;
    //private GameObject scytheTaiden;
    //private SkinnedMeshRenderer skinnedMeshRenderer;

    //void Awake() {
    //    scythe = GetComponent<ScytheComponent>().Scythe;
    //    //scytheTaiden = GetComponent<ScytheComponent>().ScytheTaiden;
    //    //skinnedMeshRenderer = scytheTaiden.GetComponent<SkinnedMeshRenderer>();
    //    enabled = false;
    //}

    //public void StartTaiden() {
    //    enabled = true;
    //}

    //public void StopTaiden() {
    //    blendBack = true;
    //}

    //void OnEnable() {
    //    delayTimer = 0;
    //    blendTimer = 0;
    //    blendBlackTimer = 0;
    //    blendBack = false;
    //    scythe.SetActive(false);
    //    //scytheTaiden.SetActive(true);
    //    UpdateBlendShapes(0);
    //}

    //void Update() {
    //    if (delayTimer <= BlendDelay) {
    //        delayTimer += Time.deltaTime;
    //        return;
    //    }
    //    if (blendTimer <= BlendTime) {
    //        blendTimer += Time.deltaTime;
    //        blendWeight = Mathf.Clamp(ScaleRange.scale(0, BlendTime, 0, 100, blendTimer), 0, 100);
    //        UpdateBlendShapes(blendWeight);
    //        return;
    //    }
    //    if (!blendBack) {
    //        return;
    //    }
    //    if (blendBlackTimer <= BlendTime) {
    //        blendBlackTimer += Time.deltaTime;
    //        blendWeight = Mathf.Clamp(ScaleRange.scale(0, BlendTime, 0, 100, blendBlackTimer), 0, 100);
    //        UpdateBlendShapes(100 - blendWeight);
    //        return;
    //    }
    //    enabled = false;
    //}

    //private void UpdateBlendShapes(float value) {
    //    skinnedMeshRenderer.SetBlendShapeWeight(NORMAL_SCYTHE_WEIGHT, 100 - value);
    //    skinnedMeshRenderer.SetBlendShapeWeight(DOUBLE_SCYTHE_WEIGHT, value);
    //}

    //void OnDisable() {
    //    scythe.SetActive(true);
    //    scytheTaiden.SetActive(false);
    //}

}
