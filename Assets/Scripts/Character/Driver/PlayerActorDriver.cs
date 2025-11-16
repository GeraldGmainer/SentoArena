using UnityEngine;
using com.ootii.Timing;
using com.ootii.Actors;

public class PlayerActorDriver : CharActorDriver {
    private const float ROTATING_SPEED = 25f;

    private PlayerInputController inputController;

    protected override void Awake() {
        base.Awake();
        inputController = GetComponent<PlayerInputController>();
    }

    public override void OnControllerLateUpdate(ICharacterController rController, float rDeltaTime, int rUpdateIndex) {
        base.OnControllerLateUpdate(rController, rDeltaTime, rUpdateIndex);
        if (networkController.isNotOwner() || Time.timeScale == 0) {
            return;
        }
        Move();
        updateTestHUD();
    }


    private void Move() {
        float deltaTime = TimeManager.SmoothedDeltaTime;
        Vector3 moveDirection = new Vector3(inputController.HorizontalAxis, 0f, inputController.VerticalAxis);

        Rotate();
        if (actorController.IsGrounded) {
            HandleJump();
            GroundMovement(moveDirection, deltaTime);
        }
        else {
            AirborneMovement(moveDirection, deltaTime);
        }
    }

    private void Rotate() {
        actorController.Rotate(Quaternion.Euler(0, inputController.MouseX * RotatingSpeed() / 60f, 0));
    }

    private void HandleJump() {
        if (inputController.GetKeyDown(Keybinding.JUMP, InputType.MOVEMENT)) {
            Jump();
        }
    }

    private void GroundMovement(Vector3 moveDirection, float deltaTime) {
        float speed = ActorDriverSpeedDeterminer.Determine(moveDirection, Settings.instance.charMovement);
        moveDirectionWorld = transform.TransformDirection(moveDirection * speed);

        if (moveDirectionWorld.sqrMagnitude > 0f) {
            actorController.Move(moveDirectionWorld * deltaTime);
        }
    }

    private void AirborneMovement(Vector3 moveDirection, float deltaTime) {
        float speed = ActorDriverSpeedDeterminer.Determine(moveDirection, Settings.instance.charMovement);
        Vector3 extraAirborneMovement = transform.TransformDirection(moveDirection * speed);
        extraAirborneMovement = Vector3.ClampMagnitude(extraAirborneMovement, speed - moveDirectionWorld.magnitude);

        moveDirectionWorld += extraAirborneMovement * deltaTime * Settings.instance.charMovement.AirborneMultiplier;

        if (moveDirectionWorld.sqrMagnitude > 0f) {
            actorController.Move(moveDirectionWorld * deltaTime);
        }
    }

    protected override void UpdateAnimator() {
        base.UpdateAnimator();
        networkController.strafe = inputController.HorizontalAxis != 0 ? inputController.HorizontalAxis / 2 : inputController.HorizontalAxis;
    }

    private void updateTestHUD() {
        if (TestsceneHUD.instance) {
            TestsceneHUD.instance.setSpeed(VelocityConverter.toSpeed(Velocity));
            TestsceneHUD.instance.setHorSpeed(VelocityConverter.toHorizontalSpeed(Velocity));
            TestsceneHUD.instance.setVertSpeed(VelocityConverter.toVerticalSpeed(Velocity));
            TestsceneHUD.instance.setInAir(!actorController.IsGrounded);
        }
    }

    public override float RotatingSpeed() {
        return ROTATING_SPEED;
    }
}
