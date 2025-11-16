using UnityEngine;

public class BlackFireballSpellStrategy : SpellStrategyBase {
    private CharActorDriver charActorDriver;
    private BlackFireballSpawner blackFireballSpawner;

    public BlackFireballSpellStrategy(CharSpellController spellController, CharHitbox charHitbox) : base(spellController, charHitbox) {
        charActorDriver = spellController.GetComponent<CharActorDriver>();
        blackFireballSpawner = new BlackFireballSpawner(spellController, charHitbox);
    }

    public override void Start(SpellCastExecute spellCastExecute) {
        base.Start(spellCastExecute);
        DetermineLookBackTarget();
        blackFireballSpawner.spawn(spellCastExecute.SpellCast.NetworkResourcePath, (ThrowableSpellSettings)spellCastExecute.SpellSettings);
        spellController.RegisterSpellAnimationEvent(Shoot);
        CustomSpellGravity();
        CameraShake(SpellSettings.CameraShakeDelay);
    }

    private void CustomSpellGravity() {
        if (SpellSettings is ICustomSpellGravity) {
            charActorDriver.CustomSpellGravity((ICustomSpellGravity)SpellSettings);
        }
    }

    private void Shoot() {
        if (playerCamera.IsLookingBack) {
            blackFireballSpawner.StartMoving(lookBackTarget);
        }
        else {
            blackFireballSpawner.StartMoving(DetermineTarget(blackFireballSpawner.getPosition()));
        }
    }
}
