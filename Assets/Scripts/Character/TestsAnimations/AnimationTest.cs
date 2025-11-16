using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {
    public float HorizontalSpeed;
    public float StartDelay = 0.5f;
    public float EndDelay = 0.5f;
    public AnimationTriggerSequence[] AnimationTriggerSequence;
    public CharOutfit Outfit = OutfitFactory.Determine(OutfitEnum.KANUU);
    public Weapon Weapon;

    protected Animator animator;
    private Vector3 startPosition;
    private CharWeaponEquipper weaponEquipper;
    private CharAppearanceHandler appearanceHandler;

    protected virtual void Awake() {
        animator = GetComponent<Animator>();
        startPosition = transform.position;
        weaponEquipper = new CharWeaponEquipper(transform);
        appearanceHandler = new CharAppearanceHandler(this);
        Invoke("StartDelayed", 0.2f);
    }

    protected virtual void StartDelayed() {
        weaponEquipper.Change(Weapon);
        appearanceHandler.Change(Outfit);
        RefreshAnimator();
        Invoke("StartLoop", StartDelay);
    }

    protected virtual void Update() {
    }

    private void StartLoop() {
        if (AnimationTriggerSequence.Length > 0) {
            StartCoroutine("AnimationLoop");
        }
    }

    IEnumerator AnimationLoop() {
        transform.position = startPosition;

        for (int i = 0; i < AnimationTriggerSequence.Length; i++) {
            TriggerAnimation(i);
            yield return new WaitForSeconds(AnimationTriggerSequence[i].TriggerDuration);
            RefreshAnimator();
        }
        Invoke("StartLoop", EndDelay);
    }

    protected virtual void TriggerAnimation(int triggerIndex) {
        animator.SetTrigger(AnimationTriggerSequence[triggerIndex].TriggerName);
    }

    private void RefreshAnimator() {
        animator.SetFloat(AnimatorHashIDs.horizontalSpeed, HorizontalSpeed);
        animator.SetLayerWeight(AnimatorLayers.SPELL_MOVING, HorizontalSpeed < 1 ? 0 : 1);
        animator.SetLayerWeight(AnimatorLayers.SPELL_IDLE, HorizontalSpeed < 1 ? 1 : 0);
    }

    public void SpellAnimationEvent() {
    }
}
