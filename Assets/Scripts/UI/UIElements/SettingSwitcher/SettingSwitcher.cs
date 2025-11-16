using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class SettingSwitcher : MonoBehaviour {
    public int defaultValue;
    public SettingsEnum settingsEnum;
    public SwitcherClick onClick = new SwitcherClick();

    private int value;

    private Text valueText;
    private Button backButton;
    private Button forwardButton;

    void Awake() {
        valueText = GetComponentsInChildren<Text>()[1];
        backButton = GetComponentsInChildren<Button>()[0];
        forwardButton = GetComponentsInChildren<Button>()[1];

        backButton.onClick.AddListener(() => { back(); });
        forwardButton.onClick.AddListener(() => { forward(); });
    }

    protected virtual void OnEnable() {
        setValue(Settings.load(settingsEnum, defaultValue));
        updateUI();
    }

    private void back() {
        click(value - 1);
    }

    private void forward() {
        click(value + 1);
    }

    private void click(int newValue) {
        int oldValue = value;
        setValue(newValue);
        if (oldValue == value) {
            return;
        }
        updateUI();
        onClick.Invoke();
        Settings.save(settingsEnum, value);
    }

    public void setValue(int value) {
        this.value = Mathf.Clamp(value, 0, getUIList().Length - 1);
    }

    private void updateUI() {
        valueText.text = getUIList()[this.value];
    }

    public virtual int getValue() {
        return value;
    }

    public abstract string[] getUIList();

    [Serializable]
    public class SwitcherClick : UnityEvent {
    }
}
