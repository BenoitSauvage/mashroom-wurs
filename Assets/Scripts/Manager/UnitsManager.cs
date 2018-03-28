using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsManager
{

    #region singleton
    private static UnitsManager instance;

    private UnitsManager() { }

    public static UnitsManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UnitsManager();

            return instance;
        }
    }
    #endregion singleton

    public List<TransformDestinations> playerUnits = new List<TransformDestinations>();
    public List<TransformDestinations> aiUnits = new List<TransformDestinations>();

    GameObject unitParent = null;

    public void Init()
    {
        if (!unitParent)
        {
            unitParent = new GameObject();
            unitParent.name = "Units";
        }
    }

    public void Update(float _dt)
    {
        if (playerUnits.Count > 0)
            UpdatePlayerUnits(_dt);

        if (aiUnits.Count > 0)
            UpdateAIUnits(_dt);
    }

    public void UpdatePlayerUnits(float _dt)
    {
        for (int i = playerUnits.Count - 1; i >= 0; i--)
        {
            TransformDestinations td = playerUnits[i];

            if (td.timePassed >= 0)
                td.script.UpdateDestination(td.end);

            td.timePassed += _dt;

            if (td.script.IsArrived())
            {
                UnitsManager.Instance.Fight(td);
                playerUnits.Remove(td);
            }
        }
    }

    public void UpdateAIUnits(float _dt)
    {
        for (int i = aiUnits.Count - 1; i >= 0; i--)
        {
            TransformDestinations td = aiUnits[i];

            if (td.timePassed >= 0)
                td.script.UpdateDestination(td.end);

            td.timePassed += _dt;

            if (td.script.IsArrived())
            {
                UnitsManager.Instance.Fight(td);
                aiUnits.Remove(td);
            }
        }
    }

    public void SendPlayerUnits(Transform _start, Transform _end, float _percentage)
    {
        House _mStart = _start.GetComponent<House>();

        float unitsToSend = Mathf.Floor(_mStart.units * _percentage);
        float _startDelay = 0f;

        for (int i = 0; i < unitsToSend; i++)
        {
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

    public void SendAIUnits(Transform _start, Transform _end, float _percentage)
    {
        Mushroom _mStart = _start.GetComponent<Mushroom>();

        float unitsToSend = Mathf.Floor(_mStart.units * _percentage);
        float _startDelay = 0f;

        for (int i = 0; i < unitsToSend; i++)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/AIUnit"));
            go.transform.position = _start.position;
            go.transform.SetParent(unitParent.transform);
            go.GetComponent<Unit>().startDelay = _startDelay;

            TransformDestinations td = new TransformDestinations(go.transform, _start, _end, _startDelay);
            aiUnits.Add(td);

            _startDelay += GV.UNIT_SEND_INTERVAL;
        }

        _mStart.units -= unitsToSend;
    }

    public void Fight(TransformDestinations _td)
    {
        House origin = _td.start.GetComponent<House>();
        House dest = _td.end.GetComponent<House>();

        if (dest.house_type == GV.MUSHROOM_HOUSE_TYPE.MUSHROOM && dest.type != origin.type)
        {
            if (origin.house_type == GV.MUSHROOM_HOUSE_TYPE.FORGE)
                dest.units -= (1 * GV.FORGE_DAMAGE_MULTIPLIER);
            else
            {
                dest.units -= 1;
                dest.labelOfUnits.text = "" + dest.units;
            }

            if (dest.units <= 0)
                dest.GetComponent<Mushroom>().SwitchTeam();
        }
        else
        {
            dest.units += 1;
            dest.labelOfUnits.text = "" + dest.units;
        }

        GameObject.Destroy(_td.unit.gameObject);
    }

    public void RemoveUnit(Transform _transform, GV.MUSHROOM_TYPE _type)
    {
        switch (_type)
        {
            case GV.MUSHROOM_TYPE.PLAYER:
                RemoveUnitFromList(_transform, playerUnits);
                break;
            case GV.MUSHROOM_TYPE.AI:
                RemoveUnitFromList(_transform, aiUnits);
                break;
        }

        GameObject.Destroy(_transform.gameObject);
    }

    private void RemoveUnitFromList(Transform _transform, List<TransformDestinations> _list)
    {
        TransformDestinations toRemove = null;

        foreach (TransformDestinations td in _list)
        {
            if (td.unit == _transform)
            {
                toRemove = td;
                break;
            }
        }

        _list.Remove(toRemove);
    }

    public class TransformDestinations
    {

        public Transform unit, start, end;
        public float timePassed = 0;
        public Unit script;

        public TransformDestinations(Transform _unit, Transform _start, Transform _end, float _delay)
        {
            unit = _unit;
            start = _start;
            end = _end;
            timePassed = -_delay;
            script = unit.GetComponent<Unit>();

            script.Init();
        }
    }

}
