using UnityEngine;

[System.Serializable]
public class CameraSettings {
    public float MouseSensitivity = 8.0f;
    public FPSCameraMode FPSCameraMode = FPSCameraMode.SMOOTHED;

    public float SpectatorSpeed = 20f;
    public float SpectatorShiftSpeed = 40f;

    public OcclusionHandling OcclusionHandling = OcclusionHandling.AlwaysZoomIn;
    public LayerMask OccludingLayers = 1;
    public string[] AffectingTags = { Tags.AffectCameraZoom };
}
