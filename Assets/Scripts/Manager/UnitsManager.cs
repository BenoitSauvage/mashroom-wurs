using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager {
	
    #region singleton
    private static UnitsManager instance;

    private UnitsManager() { }

    public static UnitsManager Instance {
        get {
            if (instance == null)
                instance = new UnitsManager();

            return instance;
        }
    }
    #endregion singleton

    public List<TransformDestinations> playerUnits = new List<TransformDestinations>();
    public List<TransformDestinations> aiUnits = new List<TransformDestinations>();

    GameObject unitParent = null;

    public void Init () {
        if (!unitParent) {
            unitParent = new GameObject();
            unitParent.name = "Units";
        }
    }

    public void UpdatePlayerUnits (float _dt) {
        for (int i = playerUnits.Count - 1; i >= 0; i--) {
            TransformDestinations td = playerUnits[i];

            if (td.timePassed >= 0)
                td.script.UpdateDestination(td.end);

            td.timePassed += _dt;

            if (td.script.IsArrived()) {
                playerUnits.Remove(td);
                GameObject.Destroy(td.unit.gameObject);
            }
        }
    }

    public void SendPlayerUnits (Transform _start, Transform _end, float _percentage) {

        Mushroom _mStart = _start.GetComponent<Mushroom>();

        float unitsToSend = Mathf.Floor(_mStart.units * _percentage);
        float _startDelay = 0f;

        for (int i = 0; i < unitsToSend; i++) {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/PlayerUnit"));
            go.transform.position = _start.position;
            go.transform.SetParent(unitParent.transform);
            go.GetComponent<Unit>().startDelay = _startDelay;

            TransformDestinations td = new TransformDestinations(go.transform, _start, _end, _startDelay);
            playerUnits.Add(td);

            _startDelay += GV.UNIT_SEND_INTERVAL;
        }

        _mStart.units -= unitsToSend;
    }


    public class TransformDestinations {

        public Transform unit, start, end;
        public float timePassed = 0;
        public Unit script;

        public TransformDestinations(Transform _unit, Transform _start, Transform _end, float _delay) {
            unit = _unit;
            start = _start;
            end = _end;
            timePassed = -_delay;
            script = unit.GetComponent<Unit>();

            script.Init();
        }
    }
   
}
