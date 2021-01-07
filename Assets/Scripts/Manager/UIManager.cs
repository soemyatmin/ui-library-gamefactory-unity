using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class UIManager : Singleton<UIManager> {
    private Canvas UICanvas;
    private GameObject panelContainer;

    private List<UIBase> basePanelPrefabList;

    private Dictionary<Type, UIBase> panelMap = new Dictionary<Type, UIBase>();

    private UIManager() { }

    void InitGameObjects() {
        UICanvas = GameObject.Find(GLOBALCONST.CANVAS).GetComponent<Canvas>();
        panelContainer = GameObject.Find(GLOBALCONST.PANEL_CONTAINER);
    }

    void InstantiatePanels() {
        basePanelPrefabList = Resources.LoadAll(GLOBALCONST.FOLDERS.PANELS, typeof(UIBase)).Cast<UIBase>().ToList<UIBase>();
        foreach (var panelPrefab in basePanelPrefabList) {
            if (panelPrefab) {
                var panel = Instantiate(panelPrefab, UICanvas.transform, false);
                panel.name = panel.name.Replace("(Clone)", "");
                if (panel.GetType() == typeof(UITop) || panel.GetType() == typeof(UIBottom)) {
                    panel.transform.SetParent(panelContainer.transform);
                }
                panelMap.Add(panel.GetType(), panel);
                panel.HidePanel();
            }
        }
    }

    void Awake() {
        InitGameObjects();
        InstantiatePanels();
    }

    void Start() {
        ShowPanel<UITop>();
        ShowPanel<UIBottom>();
    }

    public UIBase GetPanel<T>() where T : UIBase {
        return panelMap[typeof(T)];
    }

    public void ShowPanel<T>() where T : UIBase {
        panelMap[typeof(T)].ShowPanel();
    }

    public void HidePanel<T>() where T : UIBase {
        panelMap[typeof(T)].HidePanel();
    }

    public void TogglePanel<T>() where T : UIBase {
        panelMap[typeof(T)].TogglePanel();
    }

    public void HideAllPanels() {
        foreach (var panel in panelMap) {
            if (panel.Key == typeof(UITop)) {
                // some condition not to hide 
            } else {
                panel.Value.HidePanel();
            }
        }
    }

}
