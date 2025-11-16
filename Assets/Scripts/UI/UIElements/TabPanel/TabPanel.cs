using UnityEngine;
using UnityEngine.UI;
using System;


public class TabPanel : MonoBehaviour {
    public TabPanelModel[] tabPanels;

    void Awake() {
        addClickListener();
        showFirstVisible();
    }

    private void showFirstVisible() {
        foreach(TabPanelModel tabPanelModel in tabPanels) {
            if(tabPanelModel.tabPane.gameObject.activeSelf) {
                showPanel(tabPanelModel);
                break;
            }
        }
    }

    public void showOnlyTabs(params int[] visibleTabs) {
        for(int i= 0; i<tabPanels.Length; i++) {
            tabPanels[i].tabPane.gameObject.SetActive(Array.IndexOf(visibleTabs, i) > -1);
        }
        showFirstVisible();
    }

    public void hide(int tab) {
        tabPanels[tab].tabPane.gameObject.SetActive(false);
        showFirstVisible();
    }

    private void addClickListener() {
        for (int i = 0; i < tabPanels.Length; i++) {
            TabPanelModel tabPanelModel = tabPanels[i];
            tabPanelModel.tabPane.onClick.AddListener(() => showPanel(tabPanelModel));
        }
    }

    private void showPanel(TabPanelModel tabPanel) {
        for (int i = 0; i < tabPanels.Length; i++) {
            tabPanels[i].tabContent.gameObject.SetActive(tabPanel == tabPanels[i]);
            tabPanels[i].tabPane.GetComponent<Text>().resizeTextForBestFit = tabPanel == tabPanels[i];
        }
    }
}
