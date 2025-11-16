using UnityEngine;
using Thinksquirrel.CShake;

public interface ICameraShake {
    CameraShake.ShakeType Type { get; }
    int NumberOfShakes { get; }
    Vector3 ShakeAmount { get; }
    Vector3 RotationAmount { get; }
    float Distance { get; }
    float Speed { get; }
    float Decay { get; }
    float UiShakeModifier { get; }
    bool MultiplyByTimeScale { get; }
}
