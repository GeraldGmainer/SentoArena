using UnityEngine;
using BeardedManStudios.Network;

public class BlackFireballMover {
    private bool canMove;
    private float speed;
    private float maxRange;

    private Vector3 target;
    private Vector3 startPosition;
    private Rigidbody rigidBody;
    private SpellBlackFireballBase blackFireball;

    public BlackFireballMover(SpellBlackFireballBase blackFireball) {
        this.blackFireball = blackFireball;
        rigidBody = blackFireball.GetComponent<Rigidbody>();
    }

    public void startMoving(Vector3 target, float speed, float maxRange) {
        this.speed = speed;
        this.maxRange = maxRange;
        canMove = true;
        startPosition = blackFireball.transform.position;
        blackFireball.transform.parent = null;
        blackFireball.transform.LookAt(target);
        this.target = target + blackFireball.transform.forward * 1000f;
    }

    public void fixedUpdate(bool IsOwner) {
        if (!canMove) {
            return;
        }
        if ((NetworkingManager.IsOnline && IsOwner) || !NetworkingManager.IsOnline) {
            checkMaxRange();
        }
        moveToTarget();
    }

    private void moveToTarget() {
        float step = speed * Time.fixedDeltaTime;
        //Debug.Log(target);
        rigidBody.MovePosition(Vector3.MoveTowards(blackFireball.transform.position, target, step));
    }

    private void checkMaxRange() {
        if (Vector3.Distance(startPosition, blackFireball.transform.position) > maxRange) {
            blackFireball.destroy();
        }
    }

    public bool isMoving() {
        return canMove;
    }
}
