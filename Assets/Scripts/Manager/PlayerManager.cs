using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {

    #region singleton
    private static PlayerManager instance;

    private PlayerManager() { }

    public static PlayerManager Instance {
        get {
            if (instance == null)
                instance = new PlayerManager();

            return instance;
        }
    }
    #endregion singleton

    bool hasClicked = false;
    Transform selectedUnit = null;

    public void Update(float _dt) {
        GetMouseInputs();
    }

    private void GetMouseInputs() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);

            if (hit.collider && hit.collider.CompareTag(GV.MUSHROOM_TAG_PLAYER)) {
                hasClicked = true;
                selectedUnit = hit.collider.transform;
            }
        }

        if (hasClicked & Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);

        if (hit.collider && (hit.collider.CompareTag(GV.MUSHROOM_TAG_AI) || hit.collider.CompareTag(GV.MUSHROOM_TAG_PLAYER))) {
                UnitsManager.Instance.SendPlayerUnits(selectedUnit, hit.collider.transform, 1);
                hasClicked = false;
                selectedUnit = null;
            }
        }
    }
}
