using UnityEngine;

public class CrosshairSpreadHandler {
    private const float SPREAD_RESET_TIME = 1.5f;
    private const float SPREAD_SMOOTH_TIME = 0.5f;
    private const float MIN_SPREAD = 1;

    private Crosshair crosshair;

    private float spreadVelocity;
    private float spreadSmooth = MIN_SPREAD;
    private float desiredSpread = MIN_SPREAD;
    private float spreadResetCounter;

    private float cameraDistance;

    public CrosshairSpreadHandler(Crosshair crosshair) {
        this.crosshair = crosshair;
    }

    public void update() {
        calculateSpreadResetCounter();
        calculateSpreadSmooth();
        crosshair.resize(spreadSmooth);
    }

    private void calculateSpreadResetCounter() {
        spreadResetCounter = Mathf.Clamp(spreadResetCounter - Time.deltaTime, 0, 999);
    }

    private void calculateSpreadSmooth() {
        if (spreadResetCounter <= 0) {
            desiredSpread = MIN_SPREAD;
        }
        spreadSmooth = Mathf.SmoothDamp(spreadSmooth, desiredSpread, ref spreadVelocity, SPREAD_SMOOTH_TIME);
    }

    public void increase(float spreadIncrease, float maxSpread) {
        desiredSpread += spreadIncrease;
        desiredSpread = Mathf.Clamp(desiredSpread, MIN_SPREAD, maxSpread);
        spreadResetCounter = SPREAD_RESET_TIME;
    }
}
