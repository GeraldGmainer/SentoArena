using UnityEngine;

public abstract class MenuBase : MonoBehaviour {
    protected RectTransform rectTransform;
    protected IngameMenuManager ingameMenuManager;
    protected MainMenuManager mainMenuManager;

    protected virtual void Awake() {
        rectTransform = GetComponent<RectTransform>();
        ingameMenuManager = transform.parent.GetComponent<IngameMenuManager>();
        mainMenuManager = transform.parent.GetComponent<MainMenuManager>();
    }

    protected virtual void OnEnable() {
    }

    public virtual void onShow() {
        showMenu();
    }

    public virtual void onBack() {
        hideMenu();
    }

    public virtual void onHide() {
        hideMenu();
    }

    protected void showMenu() {
        rectTransform.gameObject.SetActive(true);
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
    }

    protected void hideMenu() {
        rectTransform.gameObject.SetActive(false);
    }


}
