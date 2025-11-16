using UnityEngine;

public abstract class PortSpellSettings : SpellSettingsBase, IPortSettings {
    [SerializeField]
    protected float minDistance = 1f;
    [SerializeField]
    protected float portDelay = 0.251f;

    public float MinDistance { get { return minDistance; } }
    public float PortDelay { get { return portDelay; } }
}
