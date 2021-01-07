using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITop : UIBase {
    public Text txtCount;
    public Button btnCounter;

    private int count = 0;

    private void Start() {
        InitGameObjects();
    }

    void InitGameObjects() {
        txtCount.text = count.ToString();
        btnCounter.onClick.AddListener(OnClickedBtnCounter);
    }

    void OnClickedBtnCounter() {
        count++;
        txtCount.text = count.ToString();
    }
}
