using System.Collections.Generic;

public class ComboHistory {
    private List<SpellCastExecute> spellCastExecutes = new List<SpellCastExecute>();

    public List<SpellCastExecute> Get { get { return spellCastExecutes; } }
    public int Length { get { return spellCastExecutes.Count; } }

    public void Add(SpellCastExecute spellCastExecute) {
        spellCastExecutes.Add(spellCastExecute);
    }

    public void Reset() {
        spellCastExecutes.Clear();
    }
}
