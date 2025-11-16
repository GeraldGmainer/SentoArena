using UnityEngine;
using com.ootii.Actors;

public abstract class CharActorDriver : CharMonoBehaviour {
    public Vector3 Velocity { get; private set; }
    public bool IsGrounded { get { return actorController.IsGrounded; } }
    public bool isGravityEnabled { get { return actorController.IsGravityEnabled; } }

    protected ActorController actorController;
    protected Vector3 moveDirectionWorld;
    private ActorDriverGravityHandler actorDriverGravityHandler;

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    protected override void Awake() {
        base.Awake();
        actorController = GetComponent<ActorController>();
        actorDriverGravityHandler = new ActorDriverGravityHandler(this);
        actorController.OnControllerPreLateUpdate += OnControllerLateUpdate;
    }

    protected override void Start() {
        base.Start();
        lastPosition = transform.position;
        if (networkController.isOwner()) {
            actorController.StepUpSpeed = Settings.instance.charMovement.RunSpeed;
            actorController.StepDownSpeed = Settings.instance.charMovement.RunSpeed;
            actorDriverGravityHandler.Start();
        }
        else {
            actorController.enabled = false;
        }
    }

    protected override void Update() {
        base.Update();
        UpdateVelocity();
        UpdateDirection();
    }

    public virtual void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex) {
        if (networkController.isOwner()) {
            UpdateAnimator();
            actorDriverGravityHandler.Update();
        }
    }


    private void UpdateVelocity() {
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        Velocity = transform.InverseTransformVector(Velocity);
        lastPosition = transform.position;
        charAnimator.velocity = Velocity;
    }

    private void UpdateDirection() {
        float direction = Math3d.SubtractRotation(transform.rotation, lastRotation).eulerAngles.y;
        if (direction > 180) {
            direction = direction - 360;
        }
        direction = Mathf.Clamp(direction, -1, 1);
        lastRotation = transform.rotation;
        charAnimator.direction = direction;
    }

    public void Jump() {
        charAnimator.Trigger(AnimatorHashIDs.jump);
        actorController.AddImpulse(transform.up * CalculateJumpForce());
    }

    private float CalculateJumpForce() {
        return Mathf.Sqrt(2 * Settings.instance.charMovement.JumpForce * Settings.instance.charMovement.Gravity * charGravity.JumpMultiplier);
    }

    protected virtual void UpdateAnimator() {
        networkController.isGrounded = actorController.IsGrounded;
    }

    public void StartOrientToGroundPortPause() {
        StartCoroutine(actorDriverGravityHandler.orientToGroundPortPauseTimer());
    }

    public void OnDeath() {
        charGravity.reset();
    }

    public virtual void OnRespawn(Vector3 newPosition, Quaternion newRotation) {
        transform.position = newPosition;
        lastPosition = newPosition;
        ActorControllerRotate(newRotation);
        actorController.SetTargetGroundNormal(Vector3.up);
        networkController.isGrounded = true;
    }

    private void ActorControllerRotate(Quaternion newRotation) {
        transform.rotation = newRotation;
        actorController.SetRotation(newRotation);
        actorController.PrevState.Rotation = newRotation;
        actorController.PrevState.RotationTilt = Quaternion.identity;
        actorController.PrevState.RotationYaw = newRotation;

        actorController.State.Rotation = newRotation;
        actorController.State.RotationTilt = Quaternion.identity;
        actorController.State.RotationYaw = newRotation;
    }

    public void CustomSpellGravity(ICustomSpellGravity customSpellGravity) {
        if (IsGrounded) {
            return;
        }
        StartCoroutine(actorDriverGravityHandler.CustomSpellGravityTimer(customSpellGravity));
    }

    public abstract float RotatingSpeed();
}

/*
public abstract class CharActorDriver : CharMonoBehaviour {
    public Vector3 Velocity { get; private set; }
    public bool IsGrounded { get { return actorController.IsGrounded; } }
    public bool isGravityEnabled { get { return actorController.IsGravityEnabled; } }

    protected ActorController actorController;
    protected Vector3 moveDirectionWorld;
    private ActorDriverGravityHandler actorDriverGravityHandler;

    private Vector3 lastPosition;
    private Quaternion lastRotation;

    protected override void Awake() {
        base.Awake();
        actorController = GetComponent<ActorController>();
        actorDriverGravityHandler = new ActorDriverGravityHandler(this);
    }

    protected override void Start() {
        base.Start();
        lastPosition = transform.position;
        if (networkController.isOwner()) {
            actorController.StepUpSpeed = Settings.instance.charMovement.RunSpeed;
            actorController.StepDownSpeed = Settings.instance.charMovement.RunSpeed;
            actorDriverGravityHandler.Start();
        }
        else {
            actorController.enabled = false;
        }
    }

    protected override void Update() {
        base.Update();
        UpdateVelocity();
        UpdateDirection();
        UpdateAnimator();
        actorDriverGravityHandler.Update();
    }

    private void UpdateVelocity() {
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        Velocity = transform.InverseTransformVector(Velocity);
        lastPosition = transform.position;
        charAnimator.velocity = Velocity;
    }

    private void UpdateDirection() {
        float direction = Math3d.SubtractRotation(transform.rotation, lastRotation).eulerAngles.y;
        if (direction > 180) {
            direction = direction - 360;
        }
        direction = Mathf.Clamp(direction, -1, 1);
        lastRotation = transform.rotation;
        charAnimator.direction = direction;
    }

    public void Jump() {
        charAnimator.Trigger(AnimatorHashIDs.jump);
        actorController.AddImpulse(transform.up * CalculateJumpForce());
    }

    private float CalculateJumpForce() {
        return Mathf.Sqrt(2 * Settings.instance.charMovement.JumpForce * Settings.instance.charMovement.Gravity * charGravity.JumpMultiplier);
    }

    protected virtual void UpdateAnimator() {
        networkController.isGrounded = actorController.IsGrounded;
    }

    public void StartOrientToGroundPortPause() {
        StartCoroutine(actorDriverGravityHandler.orientToGroundPortPauseTimer());
    }

    public void OnDeath() {
        charGravity.reset();
    }

    public void OnRespawn(Vector3 newPosition, Quaternion newRotation) {
        transform.position = newPosition;
        lastPosition = newPosition;
        ActorControllerRotate(newRotation);
        actorController.SetTargetGroundNormal(Vector3.up);
        networkController.isGrounded = true;
    }

    private void ActorControllerRotate(Quaternion newRotation) {
        transform.rotation = newRotation;
        actorController.SetRotation(newRotation);
        actorController.PrevState.Rotation = newRotation;
        actorController.PrevState.RotationTilt = Quaternion.identity;
        actorController.PrevState.RotationYaw = newRotation;

        actorController.State.Rotation = newRotation;
        actorController.State.RotationTilt = Quaternion.identity;
        actorController.State.RotationYaw = newRotation;
    }

    public void CustomSpellGravity(ICustomSpellGravity customSpellGravity) {
        if (IsGrounded) {
            return;
        }
        StartCoroutine(actorDriverGravityHandler.CustomSpellGravityTimer(customSpellGravity));
    }

    public abstract float RotatingSpeed();
}
*/
