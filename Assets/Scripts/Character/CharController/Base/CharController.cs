using UnityEngine;
using BeardedManStudios.Network;

public abstract class CharController : CharNetworkMonoBehaviour, ICharController, IDamageable {
    public string charName = "Player";
    public CharOutfit outfit;

    public bool isDead { get { return healthHandler.Health <= 0; } }
    public Weapon currentWeapon { get; private set; }
    public IWeaponComponent currentWeaponComponent { get { return weaponEquipper.CurrentWeaponComponents[0]; } }

    public CharAppearanceHandler appearanceHandler { get; private set; }

    protected CharHealthHandler healthHandler;
    protected CharWeaponEquipper weaponEquipper;
    protected CharFootstepHandler footStepHandler;
    protected CharRagdollHandler charRagdollHandler;

    protected override void Awake() {
        base.Awake();
        healthHandler = new CharHealthHandler(this, Settings.instance.charSettings.MaxHealth);
        weaponEquipper = new CharWeaponEquipper(transform);
        footStepHandler = new CharFootstepHandler(this);
        charRagdollHandler = new CharRagdollHandler(this);
        appearanceHandler = new CharAppearanceHandler(this);
    }

    protected override void Start() {
        base.Start();
        healthHandler.Start();
        appearanceHandler.Change(outfit);
    }

    public virtual void ChangeWeapon(Weapon weapon) {
        if (networkController.isOwner()) {
            networkController.weapon = weapon;
        }
        currentWeapon = weapon;
        weaponEquipper.Change(weapon);
        charAnimator.changeWeapon(currentWeaponComponent);
    }

    public virtual void receiveDamage(SpellDamage spellDamage) {
        if (NetworkingManager.IsOnline) {
            AuthoritativeRPC("RPC_receiveDamage", OwningNetWorker, OwningPlayer, true, spellDamage.damage, spellDamage.direction);
        }
        else {
            onReceiveDamage(spellDamage);
        }
    }

    [BRPC]
    public void RPC_receiveDamage(float damage, Vector3 direction) {
        if (!IsOwner) {
            return;
        }
        onReceiveDamage(new SpellDamage(damage, direction));
    }

    protected virtual void onReceiveDamage(SpellDamage spellDamage) {
        healthHandler.ReceiveDamage(spellDamage);
    }

    public virtual void OnHealthUpdate() {
    }

    public virtual void OnDeath(SpellDamage spellDamage) {
        Chat.instance.addSystemMessage(charName + " died");
        actorDriver.OnDeath();
        if (NetworkingManager.IsOnline) {
            RPC("RPC_onDeath", spellDamage.direction);
        }
        else {
            RPC_onDeath(spellDamage.direction);
        }
    }

    [BRPC]
    public void RPC_onDeath(Vector3 spellDamageDirection) {
        charRagdollHandler.onDeath(spellDamageDirection);
    }

    public virtual void onRespawn(Vector3 newPosition, Quaternion newRotation) {
        charRagdollHandler.onRespawn();
        actorDriver.OnRespawn(newPosition, newRotation);
        RPC("RPC_onRespawn", NetworkReceivers.Others);
        healthHandler.Start();
    }

    [BRPC]
    public void RPC_onRespawn() {
        charRagdollHandler.onRespawn();
    }

    //public void StartTaiden() {
    //    RPC_StartTaiden();
    //    RPC("RPC_StartTaiden", NetworkReceivers.Others);
    //}

    //[BRPC]
    //public void RPC_StartTaiden() {
    //    GetComponentInChildren<ScytheTaidenBlender>().StartTaiden();
    //}

    //public void StopTaiden() {
    //    RPC_StopTaiden();
    //    RPC("RPC_StopTaiden", NetworkReceivers.Others);
    //}

    //[BRPC]
    //public void RPC_StopTaiden() {
    //    GetComponentInChildren<ScytheTaidenBlender>().StopTaiden();
    //}

    public virtual void SpawnLeftFootstepAnimationEvent(string animationType) {
        footStepHandler.SpawnLeftFootstepAnimationEvent(animationType);
    }

    public virtual void SpawnRightFootstepAnimationEvent(string animationType) {
        footStepHandler.SpawnRightFootstepAnimationEvent(animationType);
    }
}
