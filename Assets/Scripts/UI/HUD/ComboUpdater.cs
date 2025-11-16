using UnityEngine;

public class ComboUpdater : MonoBehaviour {
    private const string PATH = "UI/HUD/ComboText";

    public RectTransform comboPanel;

    public void addCombo(string combo) {
        spawnComboText(combo);
    }

    private void spawnComboText(string combo) {
        GameObject go = (GameObject)Instantiate(Resources.Load(PATH));
        go.transform.SetParent(comboPanel.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = Vector3.zero;
        go.GetComponent<ComboText>().setText(combo);
    }
}
