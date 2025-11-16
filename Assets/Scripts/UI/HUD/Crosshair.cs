using UnityEngine;

public class Crosshair : MonoBehaviour {
    private const float MAX_SCALE = 1.5f;
    private const float MAX_SIZE = 12f;
    private const float MAX_WIDTH = 1.8f;

    private RectTransform parent;
    private RectTransform left;
    private RectTransform right;
    private RectTransform up;
    private RectTransform down;

    private float parentStartWidth;
    private float lineStartWidth;
    private float lineStartHeight;

    void Awake() {
        parent = GetComponentsInChildren<RectTransform>()[0];
        left = GetComponentsInChildren<RectTransform>()[1];
        right = GetComponentsInChildren<RectTransform>()[2];
        up = GetComponentsInChildren<RectTransform>()[3];
        down = GetComponentsInChildren<RectTransform>()[4];

        lineStartWidth = left.rect.width;
        lineStartHeight = left.rect.height;
        parentStartWidth = parent.rect.width;
    }

    public void resize(float scale) {
        updateSize(scale);
        updateScale(Mathf.Clamp(ScaleRange.scale(1, MAX_SIZE, 1, MAX_SCALE, scale), 1, MAX_SCALE));
        updateWidth(ScaleRange.scale(1, MAX_SIZE, 1, MAX_WIDTH, scale));
    }

    public float getSpreadPixel() {
        return parent.rect.width;
    }

    private void updateScale(float scale) {
        parent.localScale = new Vector3(scale, scale, scale);
    }

    private void updateSize(float scale) {
        parent.sizeDelta = new Vector2(parentStartWidth * scale, parentStartWidth * scale);
    }

    private void updateWidth(float scale) {
        left.sizeDelta = new Vector2(lineStartWidth * scale, lineStartHeight);
        right.sizeDelta = new Vector2(lineStartWidth * scale, lineStartHeight);
        up.sizeDelta = new Vector2(lineStartHeight, lineStartWidth * scale);
        down.sizeDelta = new Vector2(lineStartHeight, lineStartWidth * scale);
    }
}
