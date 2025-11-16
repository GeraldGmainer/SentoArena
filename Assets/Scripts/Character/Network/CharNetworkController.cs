using UnityEngine;
using BeardedManStudios.Network;

public class CharNetworkController : NetworkedMonoBehavior {
    [HideInInspector]
    [NetSync("changeWeapon", NetworkCallers.Others)]
    public Weapon weapon = (Weapon)9999;

    [HideInInspector]
    [NetSync]
    public bool isGrounded;
    [HideInInspector]
    [NetSync(NetSync.Interpolate.True)]
    public float strafe;
    [HideInInspector]
    [NetSync(NetSync.Interpolate.True)]
    public Vector3 lookAtCursorPosition;

    private CharController charController;

    void Awake() {
        charController = GetComponent<CharController>();
    }

    void Start() {
        isGrounded = true;
    }

    public void changeWeapon() {
        charController.ChangeWeapon(weapon);
    }

    public bool isOwner() {
        return (NetworkingManager.IsOnline && IsOwner) || !NetworkingManager.IsOnline;
    }

    public bool isNotOwner() {
        return NetworkingManager.IsOnline && !IsOwner;
    }
}
