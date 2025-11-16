using UnityEngine;

public class BotDeadState : BotStateBase {
    public BotDeadState(IAIController AIController) : base(AIController) {
    }

    public override void OnEnter() {
        base.OnEnter();
        m_AIController.m_emoryPoint = Vector3.zero;
        m_AIController.UpdateStateCubeColor(Color.black);
    }

}
