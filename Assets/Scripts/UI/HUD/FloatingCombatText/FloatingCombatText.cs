using UnityEngine;

public class FloatingCombatText : MonoBehaviour {
    private const string FLOATING_COMBAT_PATH = "UI/HUD/FloatingCombatTextMessage";
    private static Color DAMAGE_DONE_COLOR = new Color(1, 0.56f, 0);
    private static Color DAMAGE_RECEIVED_COLOR = new Color(1, 0, 0);

    public RectTransform floatingCombatTextPanel;

    public static FloatingCombatText instance;

    void Awake() {
        instance = this;
    }

    public void addDamageDone(SpellDamage spellDamage) {
        addMessage(spellDamage, DAMAGE_DONE_COLOR);
    }

    public void addDamageReceived(SpellDamage spellDamage) {
        addMessage(spellDamage, DAMAGE_RECEIVED_COLOR);
    }

    private void addMessage(SpellDamage spellDamage, Color color) {
        string dmg = spellDamage.damage.ToString("0.0");
        GameObject go = (GameObject)Instantiate(Resources.Load(FLOATING_COMBAT_PATH));
        go.transform.SetParent(floatingCombatTextPanel.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<FloatingCombatTextMessage>().setDamageReceived(dmg, color);
    }
}
