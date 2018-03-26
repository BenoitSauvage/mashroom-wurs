using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager {
    
    #region singleton
    private static UIManager instance;

    private UIManager() { }

    public static UIManager Instance {
        get {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }
    }
    #endregion singleton

    UI ui;

    public void Init (UI _ui) {
        ui = _ui;
    }

    public void Update (float _dt) {
        float aiCount = MushroomManager.Instance.GetAIUnitCount();
        float playerCount = MushroomManager.Instance.GetPlayerUnitCount();

        ui.UpdateSlider(aiCount, playerCount);
    }

    public float GetUnitPercentage () {
        return ui.GetSelectedPercentage();
    }
}
