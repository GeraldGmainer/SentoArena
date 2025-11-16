using UnityEngine;

public interface IThrowableSpell {
    void onEnvironmentalHit(Collider col);
    void startMoving(Vector3 target);
    void IgnoreCollision(Collider otherCollider);
    void destroy();
}
