using UnityEngine;
using UnityEngine.UI;

public class FPSUpdater {
    private const string fpsDisplay = "{0} FPS";
    private const float fpsMeasurePeriod = 0.5f;

    private int m_CurrentFps;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private Text fpsText;

    public FPSUpdater(Text fpsText) {
        this.fpsText = fpsText;
        m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
    }

    public void update() {
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod) {
            m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
            fpsText.text = string.Format(fpsDisplay, m_CurrentFps);
        }
    }
}
