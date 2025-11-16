using UnityEngine;
using System.Collections;

public class SpellTimer {
    private const float FRAME_SPAZI = 0.01f;

    private CharSpellController spellController;

    public bool isDelayedNextSpellCastCoroutineActive { get; set; }
    public delegate void TimerCallback();

    private Coroutine comboResetCoroutine;
    private Coroutine delayedNextSpellCastCoroutine;

    public SpellTimer(CharSpellController spellController) {
        this.spellController = spellController;
    }

    public void StartComboResetTimer() {
        stopComboResetCoroutine();
        comboResetCoroutine = spellController.StartCoroutine(comboResetTimer());
    }

    private IEnumerator comboResetTimer() {
        yield return new WaitForSeconds(CharSpellController.COMBO_RESET_TIME);
        spellController.ComboReset();
    }



    public void startDelayedNextSpellCastTimer(float delay, TimerCallback callback) {
        stopComboResetCoroutine();
        stopDelayedNextSpellCastCoroutine();
        spellController.RespectWeaponChange();
        delayedNextSpellCastCoroutine = spellController.StartCoroutine(nextDelayedNextSpellCast(delay, callback));
    }

    IEnumerator nextDelayedNextSpellCast(float delay, TimerCallback callback) {
        isDelayedNextSpellCastCoroutineActive = true;
        yield return new WaitForSeconds(delay);
        isDelayedNextSpellCastCoroutineActive = false;
        callback();
    }


    public void stopComboResetCoroutine() {
        if (comboResetCoroutine != null) {
            spellController.StopCoroutine(comboResetCoroutine);
        }
    }

    private void stopDelayedNextSpellCastCoroutine() {
        if (delayedNextSpellCastCoroutine != null) {
            spellController.StopCoroutine(delayedNextSpellCastCoroutine);
        }
    }
}
