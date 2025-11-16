using UnityEngine;
using BeardedManStudios.Network;

public class CharAnimator : SimpleNetworkedMonoBehavior {
    public const float TRANSITION_DAMP = 100f;

    public float direction { get; set; }
    public Vector3 velocity { get; set; }
    public bool PauseLookIK { get; set; }
    public bool doFirstPersonHeadIK { get; set; }

    protected Animator animator;
    protected LookIKHandler lookIKHandler;
    protected AnimatorLayerHandler layerHandler;
    protected CharNetworkController networkController;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
        networkController = GetComponent<CharNetworkController>();
        lookIKHandler = new LookIKHandler(this, animator);
        layerHandler = new AnimatorLayerHandler(animator);
    }

    protected virtual void Update() {
        if (Time.timeScale == 0) {
            return;
        }
        animator.SetFloat(AnimatorHashIDs.horizontalSpeed, VelocityConverter.toHorizontalSpeed(velocity), 10, TRANSITION_DAMP * Time.deltaTime);
        animator.SetFloat(AnimatorHashIDs.direction, direction, 20, TRANSITION_DAMP * Time.deltaTime);
        animator.SetFloat(AnimatorHashIDs.strafe, networkController.strafe, 5, TRANSITION_DAMP * Time.deltaTime);
        animator.SetBool(AnimatorHashIDs.isMoving, VelocityConverter.isMoving(velocity));
        animator.SetBool(AnimatorHashIDs.inAir, !networkController.isGrounded);
    }

    protected virtual void OnAnimatorIK() {
    }

    public virtual void changeWeapon(IWeaponComponent weaponComponent) {
        layerHandler.changeWeapon(weaponComponent);
    }

    public void Trigger(int trigger) {
        animator.SetTrigger(trigger);
        RPC("RPC_trigger", NetworkReceivers.Others, trigger);
    }

    [BRPC]
    public void RPC_trigger(int trigger) {
        animator.SetTrigger(trigger);
    }

    public void StartCasting() {
        RPC_StartCasting(IsMoving());
        RPC("RPC_StartCasting", NetworkReceivers.Others, IsMoving());
    }

    [BRPC]
    public void RPC_StartCasting(bool isMoving) {
        layerHandler.StartCasting(isMoving);
    }

    public bool IsMoving() {
        return VelocityConverter.isMoving(velocity) || !networkController.isGrounded;
    }

}
