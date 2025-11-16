using UnityEngine;

public class SpellCollisionDetector {
    public RaycastHit anticipatedCollision { get; private set; }

    private MonoBehaviour spell;
    private Vector3 target = Vector3.zero;
    private LayerMask layerMask;
    private float maxRange;

    public SpellCollisionDetector(MonoBehaviour spell, float maxRange) {
        this.spell = spell;
        this.maxRange = maxRange;
        layerMask = (1 << Layers.CHARACTER_HITBOX) | (1 << Layers.DEFAULT);
    }

    public void update() {
        if (target == Vector3.zero) {
            return;
        }
        performRaycast();
    }

    private void performRaycast() {
        RaycastHit hit;
        float maxDistance = Vector3.Distance(spell.transform.position, target) + 6;
        Vector3 startPos = spell.transform.position - spell.transform.forward * 5;
        //Debug.Log(maxDistance);
        //Debug.DrawRay(startPos, (target - spell.transform.position) * maxDistance, Color.red, 0);
        if (Physics.Raycast(startPos, (target - spell.transform.position), out hit, maxDistance, layerMask)) {
            anticipatedCollision = hit;
        }
    }

    public void setTarget(Vector3 target) {
        this.target = target + spell.transform.forward * (maxRange + 1);
    }
}
