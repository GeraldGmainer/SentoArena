using UnityEngine;

public class ThrowableSpellEnvironmentCollider : MonoBehaviour {
    protected Collider col;

    private IThrowableSpell throwableSpell;

    void Awake() {
        col = GetComponent<Collider>();
    }

    public void enable() {
        col.enabled = true;
    }

    void OnTriggerEnter(Collider other) {
        throwableSpell.onEnvironmentalHit(other);
    }

    public void setParent(IThrowableSpell throwableSpell) {
        this.throwableSpell = throwableSpell;
    }
}
