using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlow : MonoBehaviour {

    public Transform PlayerChamps;
    public Transform AIChamps;

    public Vector2Int AIUnitsSpawnRange = new Vector2Int(5, 10);

	// Use this for initialization
	void Start () {
        UIManager.Instance.Init(GetComponent<UI>());
        MushroomManager.Instance.Init(PlayerChamps, AIChamps);
        AIManager.Instance.Init(AIUnitsSpawnRange);
        UnitsManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        MushroomManager.Instance.Update(dt);
        PlayerManager.Instance.Update(dt);
        AIManager.Instance.Update(dt);
        UIManager.Instance.Update(dt);

        if (UnitsManager.Instance.playerUnits.Count > 0)
            UnitsManager.Instance.UpdatePlayerUnits(dt);

        if (UnitsManager.Instance.aiUnits.Count > 0)
            UnitsManager.Instance.UpdateAIUnits(dt);
	}
}
