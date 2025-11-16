using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MapPreview : MonoBehaviour {
    public Image defaultScreenShot;
    public Image planetArenaScreenShot;
    public Image jumpingPuzzleScreenShot;

    private List<Image> screenShots;

    void Awake() {
        screenShots = new List<Image>();
        screenShots.Add(defaultScreenShot);
        screenShots.Add(planetArenaScreenShot);
        screenShots.Add(jumpingPuzzleScreenShot);
    }

    void Start() {
        hideAll();
    }

    public void changeTo(MapEnum mapEnum) {
        switch (mapEnum) {
            case MapEnum.PLANET_ARENA:
            hideScreenShots();
            showScreenShot(planetArenaScreenShot);
            break;

            case MapEnum.JUMPING_PUZZLE:
            hideScreenShots();
            showScreenShot(jumpingPuzzleScreenShot);
            break;

            case MapEnum.TEST_MAP:
            hideScreenShots();
            showScreenShot(planetArenaScreenShot);
            break;

            default:
            Debug.LogError("WTF");
            break;
        }
    }

    public void showDefault() {
        hideScreenShots();
        showScreenShot(defaultScreenShot);
    }

    public void hideAll() {
        hideScreenShots();
    }

    private void hideScreenShots() {
        foreach (Image img in screenShots) {
            img.gameObject.SetActive(false);
        }
    }

    private void showScreenShot(Image img) {
        img.gameObject.SetActive(true);
    }
}
