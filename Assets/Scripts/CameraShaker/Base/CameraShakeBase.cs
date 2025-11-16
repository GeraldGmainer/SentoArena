using UnityEngine;
using Thinksquirrel.CShake;

public abstract class CameraShakeBase : ICameraShake {
    [SerializeField]
    protected CameraShake.ShakeType type = CameraShake.ShakeType.CameraMatrix;
    [SerializeField]
    protected int numberOfShakes = 1;
    [SerializeField]
    protected Vector3 shakeAmount = new Vector3(0f, 0f, 1f);
    [SerializeField]
    protected Vector3 rotationAmount = Vector3.zero;
    [SerializeField]
    protected float distance = 0.9f;
    [SerializeField]
    protected float speed = 35f;
    [SerializeField]
    protected float decay = 0;
    [SerializeField]
    protected float uiShakeModifier = 1f;
    [SerializeField]
    protected bool multiplyByTimeScale = true;


    protected CameraShakeBase() {
    }

    public CameraShake.ShakeType Type { get { return type; } }
    public int NumberOfShakes { get { return numberOfShakes; } }
    public Vector3 ShakeAmount { get { return shakeAmount; } }
    public Vector3 RotationAmount { get { return rotationAmount; } }
    public float Distance { get { return distance; } }
    public float Speed { get { return speed; } }
    public float Decay { get { return decay; } }
    public float UiShakeModifier { get { return uiShakeModifier; } }
    public bool MultiplyByTimeScale { get { return multiplyByTimeScale; } }
}
