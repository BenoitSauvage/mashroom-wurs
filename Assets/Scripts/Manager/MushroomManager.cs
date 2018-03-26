using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager
{

    #region singleton
    private static MushroomManager instance;

    private MushroomManager() { }

    public static MushroomManager Instance {
        get {
            if (instance == null)
                instance = new MushroomManager();

            return instance;
        }
    }
    #endregion singleton

    public Dictionary<Transform, Mushroom> m_player = new Dictionary<Transform, Mushroom>();
    public Dictionary<Transform, Mushroom> m_ai = new Dictionary<Transform, Mushroom>();

    Transform playerParent;
    Transform aiParent;

    public void Init(Transform _player, Transform _ai) {
        playerParent = _player;
        aiParent = _ai;

        foreach (Transform player in playerParent)
            m_player.Add(player, player.GetComponent<Mushroom>());

        foreach (Transform ai in aiParent)
            m_ai.Add(ai, ai.GetComponent<Mushroom>());
    }

    public void Update(float _dt) {
        foreach (KeyValuePair<Transform, Mushroom> kv in m_player)
            kv.Value.MushroomUpdate(_dt);

        foreach (KeyValuePair<Transform, Mushroom> kv in m_ai)
            kv.Value.MushroomUpdate(_dt);
    }

    public Transform GetRandomPlayerMushroom() {
        int rand = Random.Range(0, m_player.Count);
        int count = 0;

        foreach (KeyValuePair<Transform, Mushroom> kv in m_player) {
            if (count == rand)
                return kv.Key;
            count++;
        }

        return null;
    }

    public Transform GetRandomAIMushroom() {
        int rand = Random.Range(0, m_ai.Count);
        int count = 0;

        foreach (KeyValuePair<Transform, Mushroom> kv in m_ai) {
            if (count == rand) 
                return kv.Key;
            count++;
        }

        return null;
    }

    public void SwitchTeam (Transform _transform, GV.MUSHROMM_TYPE _type, Mushroom _mushroom) {
        switch (_type) {
            case GV.MUSHROMM_TYPE.PLAYER:
                m_ai.Remove(_transform);
                m_player.Add(_transform, _mushroom);
                _transform.SetParent(playerParent);
                _transform.tag = GV.MUSHROOM_TAG_PLAYER;
                break;
            case GV.MUSHROMM_TYPE.AI:
                m_player.Remove(_transform);
                m_ai.Add(_transform, _mushroom);
                _transform.SetParent(aiParent);
                _transform.tag = GV.MUSHROOM_TAG_AI;
                break;
        }
    }

}
