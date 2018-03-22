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

    Dictionary<Transform, Mushroom> m_player = new Dictionary<Transform, Mushroom>();
    Dictionary<Transform, Mushroom> m_ai = new Dictionary<Transform, Mushroom>();

    public void Init(List<Transform> _player, List<Transform> _ai) {
        foreach (Transform player in _player)
            m_player.Add(player, player.GetComponent<Mushroom>());

        foreach (Transform ai in _ai)
            m_ai.Add(ai, ai.GetComponent<Mushroom>());
    }

    public void Update(float _dt) {
        foreach (KeyValuePair<Transform, Mushroom> kv in m_player)
            kv.Value.MushroomUpdate(_dt);

        foreach (KeyValuePair<Transform, Mushroom> kv in m_ai)
            kv.Value.MushroomUpdate(_dt);
    }

    public void UpdatePlayerUnitNumber (Transform _mushroom, int _unitsToRemove) {
        foreach (KeyValuePair<Transform, Mushroom> kv in m_player)
            if (kv.Key == _mushroom)
                kv.Value.units -= _unitsToRemove;
    }

}
