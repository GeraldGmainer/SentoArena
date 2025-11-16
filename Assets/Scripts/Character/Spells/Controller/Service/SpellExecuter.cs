using UnityEngine;

public class SpellExecuter {
    private SpellTimer spellTimer;
    private CharSpellController spellController;

    private SpellCastExecute spellCastExecute;
    private SpellCastExecute lastSpellCastExecute;
    private SpellSpellStrategyDeterminer spellStrategyDeterminer;

    public SpellExecuter(CharSpellController spellController, SpellTimer spellTimer) {
        this.spellController = spellController;
        this.spellTimer = spellTimer;
        spellStrategyDeterminer = new SpellSpellStrategyDeterminer(spellController);
    }

    public void Execute(SpellCastExecute spellCastExecute) {
        if (spellCastExecute.SpellCast == null) {
            Debug.Log("no spell to execute");
            return;
        }
        this.spellCastExecute = spellCastExecute;
        if (!spellController.IsCasting && !spellTimer.isDelayedNextSpellCastCoroutineActive) {
            this.spellCastExecute = spellCastExecute;
            TryExecute();
        }
        else if (spellController.IsCasting && IsNextAnimationReady() && !spellTimer.isDelayedNextSpellCastCoroutineActive) {
            spellTimer.startDelayedNextSpellCastTimer(TimeUntilCurrentCastFinished(), TryExecute);
        }
    }

    public bool cannotExecute() {
        return spellController.IsCasting && !IsNextAnimationReady();
    }

    private bool IsNextAnimationReady() {
        return (LastSpellRemainingTime() / lastSpellCastExecute.SpellSettings.AnimationDuration >
                lastSpellCastExecute.SpellSettings.NextAnimationCanBeFiredAtPercent);
    }

    private float LastSpellRemainingTime() {
        return (Time.time - lastSpellCastExecute.executeTimestamp);
    }

    private float TimeUntilCurrentCastFinished() {
        return lastSpellCastExecute.SpellSettings.AnimationDuration - LastSpellRemainingTime();
    }

    private void TryExecute() {
        ISpellStrategy strategy = spellStrategyDeterminer.Determine(spellCastExecute.SpellCast);
        if (strategy.CanExecute(spellCastExecute)) {
            ExecuteNow(strategy);
        }
    }

    private void ExecuteNow(ISpellStrategy strategy) {
        spellTimer.stopComboResetCoroutine();
        if (spellCastExecute.doComboReset) {
            spellController.ComboReset();
        }
        //Debug.Log(spellCastExecute.comboName + " / " + spellCastExecute.SpellCast.ToString());
        spellController.ComboHistory.Add(spellCastExecute);
        strategy.Start(spellCastExecute);
        spellController.StartCasting(strategy);

        if (spellCastExecute.isComboCompleted) {
            spellController.ComboReset();
        }

        lastSpellCastExecute = spellCastExecute;
        lastSpellCastExecute.executeTimestamp = Time.time;
    }


    public void ExecuteChargeKeyUp() {
        ((ISpellChargeStrategy)spellController.CurrentSpell).OnKeyUp();
    }
}
