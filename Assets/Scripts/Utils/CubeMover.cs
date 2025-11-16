using UnityEngine;
using System.Collections;

public class CubeMover : MonoBehaviour {
    public float speed = 10f;
    public Vector3 target = new Vector3(0, 0, 25);

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool moveRight;

    void Start() {
        startPosition = transform.position;
        endPosition = transform.position + target;
        moveRight = true;
    }

    void Update() {
        if (moveRight) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPosition) < 0.1f) {
                moveRight = false;
            }
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f) {
                moveRight = true;
            }
        }
    }
}
