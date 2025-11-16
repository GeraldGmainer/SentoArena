using UnityEngine;

public class BlackFireballTaidenTest : AnimationTest {
    public float StopTaidenTime = 3f;

    private ScytheTaidenBlender scytheTaidenBlender;

    protected override void TriggerAnimation(int triggerIndex) {
        base.TriggerAnimation(triggerIndex);
        //if (scytheTaidenBlender == null) {
        //    scytheTaidenBlender = GetComponentInChildren<ScytheTaidenBlender>();
        //}
        //if (triggerIndex == 0) {
        //    scytheTaidenBlender.StartTaiden();
        //    Invoke("StopTaiden", StopTaidenTime);
        //}
    }

    //private void StopTaiden() {
    //    scytheTaidenBlender.StopTaiden();
    //}
}
