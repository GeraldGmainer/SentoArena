using UnityEngine;
using com.ootii.Geometry;
using com.ootii.Timing;

public class BotActorDriver : CharActorDriver {
    public float ROTATING_SPEED = 120f;



    public override void OnRespawn(Vector3 newPosition, Quaternion newRotation) {
        //nix machen, funktioniert nicht mit _UseNavMeshPosition = true
    }




    public bool _UseNavMeshPosition = false;

    public Transform _Target = null;
    public Transform Target {
        get { return _Target; }

        set {
            _Target = value;
            if (_Target == null) {
                navMeshAgent.Stop();
                mHasArrived = false;
                mIsInSlowDistance = false;

                mIsTargetSet = false;
                _TargetPosition = Vector3Ext.Null;

                actorController.SetRelativeVelocity(Vector3.zero);
            }
            else {
                mIsTargetSet = true;
                _TargetPosition = _Target.position;
            }
        }
    }

    /// <summary>
    /// Target we're moving towards
    /// </summary>
    public Vector3 _TargetPosition = Vector3.zero;
    public Vector3 TargetPosition {
        get { return _TargetPosition; }

        set {
            _Target = null;
            _TargetPosition = value;

            if (_TargetPosition == Vector3Ext.Null) {
                navMeshAgent.Stop();
                mHasArrived = false;
                mIsInSlowDistance = false;

                mIsTargetSet = false;

                actorController.SetRelativeVelocity(Vector3.zero);
            }
            else {
                mIsTargetSet = true;
            }
        }
    }

    /// <summary>
    /// Determines how far from the destination we'll consider
    /// us to have arrived
    /// </summary>
    public float _StopDistance = 0.1f;

    /// <summary>
    /// Distance we'll use to start slowing down so we can arrive nicely.
    /// </summary>
    public float _SlowDistance = 4.0f;

    /// <summary>
    /// Speed we'll ultimately reduce to before stopping
    /// </summary>
    public float _SlowFactor = 0.25f;

    /// <summary>
    /// Height of the path from the actual navmesh surface. This is
    /// This height is added to the path by unity
    /// </summary>
    public float _PathHeight = 0.05f;

    protected bool mIsTargetSet = false;
    public bool IsTargetSet {
        get { return mIsTargetSet; }
    }

    protected bool mHasArrived = false;
    public bool HasArrived {
        get { return mHasArrived; }
    }

    protected bool mIsInSlowDistance = false;
    protected Vector3 mWaypoint = Vector3.zero;
    protected Vector3 mAgentDestination = Vector3.zero;
    protected Vector3 mTargetVector = Vector3.zero;
    protected float mTargetDistance = 0f;
    protected UnityEngine.AI.NavMeshAgent navMeshAgent = null;
    protected bool mFirstPathSet = false;
    protected bool mFirstPathValid = false;

    protected override void Awake() {
        base.Awake();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    protected override void Start() {
        base.Start();
        if (_Target != null) {
            Target = _Target;
        }
        else if (_TargetPosition.magnitude > 0f) {
            TargetPosition = _TargetPosition;
        }
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.speed = Settings.instance.charMovement.RunSpeed;
        navMeshAgent.angularSpeed = RotatingSpeed();
    }

    public void ClearTarget() {
        _Target = null;
        _TargetPosition = Vector3Ext.Null;

        navMeshAgent.Stop();

        mHasArrived = false;
        mFirstPathSet = false;
        mFirstPathValid = false;
        mIsInSlowDistance = false;
        mIsTargetSet = false;

        actorController.SetRelativeVelocity(Vector3.zero);
    }

    protected override void Update() {
        base.Update();
        if (!mIsTargetSet) {
            return;
        }

        moveToTarget();
    }

    private void moveToTarget() {
        // Simulated input for the animator
        Vector3 lMovement = Vector3.zero;
        Quaternion lRotation = Quaternion.identity;

        // Check if our first path is set and done
        if (mFirstPathSet && navMeshAgent.hasPath && !navMeshAgent.pathPending) {
            mFirstPathValid = true;
        }

        // Set the destination
        if (_Target != null) { _TargetPosition = _Target.position; }
        SetDestination(_TargetPosition);

        // Determine if we're at the destination
        mTargetVector = mAgentDestination - transform.position;
        mTargetDistance = mTargetVector.magnitude;

        // Check if we've arrived
        if (_UseNavMeshPosition) {
            if (!navMeshAgent.pathPending &&
                navMeshAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete &&
                navMeshAgent.remainingDistance == 0f) {
                ClearTarget();
                mHasArrived = true;
                mFirstPathSet = false;
                mFirstPathValid = false;

                OnArrived();
            }
        }
        else {
            if (mTargetDistance < _StopDistance) {
                ClearTarget();
                mHasArrived = true;

                OnArrived();
            }
        }

        // Determine the next move
        if (!mHasArrived && mFirstPathValid) {
            // Hold on to our next position before we change it
            if (navMeshAgent.hasPath && !navMeshAgent.pathPending) {
                mWaypoint = navMeshAgent.steeringTarget;
            }

            // Determine if we're within the slow distance. We only want to fire the 
            // event once
            if (_SlowDistance > 0f && mTargetDistance < _SlowDistance) {
                if (!mIsInSlowDistance) { OnSlowDistanceEntered(); }
                mIsInSlowDistance = true;
            }

            CalculateMove(mWaypoint, ref lMovement, ref lRotation);

            // Check if we've reached the destination
            if (!navMeshAgent.pathPending) {
                actorController.Move(lMovement);
                actorController.Rotate(lRotation);
            }

            // Force the agent to stay with our actor. This way, the path is
            // alway relative to our current position. Then, we can use the AC
            // to move to a valid position.
            if (!_UseNavMeshPosition) {
                navMeshAgent.nextPosition = transform.position;
            }
        }
    }

    protected virtual void CalculateMove(Vector3 rWaypoint, ref Vector3 rMove, ref Quaternion rRotate) {
        float lDeltaTime = TimeManager.SmoothedDeltaTime;

        Vector3 lDirection = rWaypoint - transform.position;
        lDirection.y = lDirection.y - _PathHeight;
        lDirection.Normalize();

        Vector3 lVerticalDirection = Vector3.Project(lDirection, transform.up);
        Vector3 lLateralDirection = lDirection - lVerticalDirection;

        float lYawAngle = Vector3Ext.SignedAngle(transform.forward, lLateralDirection);

        rRotate = Quaternion.AngleAxis(Mathf.Sign(lYawAngle) * Mathf.Min(Mathf.Abs(lYawAngle), RotatingSpeed() * lDeltaTime), transform.up);

        if (_UseNavMeshPosition) {
            rMove = navMeshAgent.nextPosition - transform.position;
        }
        else {
            float lMoveSpeed = Velocity.magnitude;
            lMoveSpeed = Settings.instance.charMovement.RunSpeed;

            float lRelativeMoveSpeed = 1f;
            if (mIsInSlowDistance && _SlowFactor > 0f) {
                float lSlowPercent = (mTargetDistance - _StopDistance) / (_SlowDistance - _StopDistance);
                lRelativeMoveSpeed = ((1f - _SlowFactor) * lSlowPercent) + _SlowFactor;
            }

            Quaternion lFutureRotation = transform.rotation * rRotate;
            rMove = lFutureRotation.Forward() * (lMoveSpeed * lRelativeMoveSpeed * lDeltaTime);
        }
    }

    protected virtual void SetDestination(Vector3 rDestination) {
        if (!mHasArrived && mAgentDestination == rDestination) {
            return;
        }

        mHasArrived = false;
        mAgentDestination = rDestination;

        if (!navMeshAgent.pathPending) {
            navMeshAgent.updatePosition = false;
            navMeshAgent.updateRotation = false;
            navMeshAgent.stoppingDistance = _StopDistance;

            navMeshAgent.ResetPath();
            navMeshAgent.SetDestination(mAgentDestination);

            mFirstPathSet = true;
        }
    }

    /// <summary>
    /// Event function for when we arrive at the destination
    /// </summary>
    protected virtual void OnArrived() {
    }

    /// <summary>
    /// Event function for when we are within the slow distance
    /// </summary>
    protected virtual void OnSlowDistanceEntered() {
    }

    public override float RotatingSpeed() {
        return ROTATING_SPEED;
    }
}
