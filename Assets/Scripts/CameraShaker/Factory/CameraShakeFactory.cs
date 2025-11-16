public class CameraShakeFactory {
    private ICameraShake hard;
    private ICameraShake hardCombo;
    private ICameraShake charge;
    private ICameraShake taiden;
    private ICameraShake port;
    private ICameraShake jumpIdle;

    public CameraShakeFactory() {
        hard = new HardCameraShake();
        hardCombo = new HardComboCameraShake();
        charge = new ChargeCameraShake();
        taiden = new TaidenCameraShake();
        port = new PortCameraShake();
        jumpIdle = new JumpIdleCameraShake();
    }

    public ICameraShake determine(CameraShakeEnum cameraShakeEnum) {
        switch (cameraShakeEnum) {
            case CameraShakeEnum.HARD:
            return hard;

            case CameraShakeEnum.HARD_COMBO:
            return hardCombo;

            case CameraShakeEnum.CHARGE:
            return charge;

            case CameraShakeEnum.TAIDEN:
            return taiden;

            case CameraShakeEnum.PORT:
            return port;

            case CameraShakeEnum.JUMP_IDLE:
            return jumpIdle;

            default:
            UnityEngine.Debug.LogError(cameraShakeEnum.ToString() + " not found in factory");
            return null;
        }
    }
}
