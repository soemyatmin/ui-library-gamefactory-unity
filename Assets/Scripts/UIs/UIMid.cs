using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMid : UIBase {
    public Button btnHide;

    private void Start() {
        InitGameObjects();
    }

    void InitGameObjects() {
        btnHide.onClick.AddListener(base.HidePanel);
    }
}
