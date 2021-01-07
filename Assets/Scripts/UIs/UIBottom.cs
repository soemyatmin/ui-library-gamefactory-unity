using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBottom : UIBase {
    public Button btnToggle;


    private void Start() {
        InitGameObjects();
    }

    void InitGameObjects() {
        btnToggle.onClick.AddListener(UIManager.Instance.TogglePanel<UIMid>);
    }
}
