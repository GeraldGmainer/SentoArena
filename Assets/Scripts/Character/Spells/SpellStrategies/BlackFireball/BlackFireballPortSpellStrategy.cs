using UnityEngine;

public class BlackFireballPortSpellStrategy : PortSpellStrategyBase {
    private float endParticleTimer;

    public BlackFireballPortSpellStrategy(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        endParticleTimer = 0;
        BlackFireballPortStartEffectPooler.instance.ShowObject(transform.position, transform.rotation);
    }

    public override void Update() {
        base.Update();
        endParticleTimer += Time.deltaTime;
        if (endParticleTimer != Mathf.Infinity && endParticleTimer >= 0.1f) {
            SpawnEndParticle();
            endParticleTimer = Mathf.Infinity;
        }
    }

    private void SpawnEndParticle() {
        BlackFireballPortEndEffectPooler.instance.ShowObject(portResult.target, transform.rotation);
    }

    protected override void OnPortDelay() {
        Vector3 direction = (portResult.target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        PortBlackLinesEffectPooler.instance.ShowObject(transform.position, lookRotation);
        base.OnPortDelay();

    }
}
