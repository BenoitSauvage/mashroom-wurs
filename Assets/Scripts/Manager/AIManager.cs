using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager {
    
    #region singleton
    private static AIManager instance;

    private AIManager() { }

    public static AIManager Instance {
        get {
            if (instance == null)
                instance = new AIManager();

            return instance;
        }
    }
    #endregion singleton

    Vector2Int spawnRate;

    int spawnTime = 0;
    float timePassed = 0f;

    public void Init (Vector2Int _spawnRate) {
        spawnRate = _spawnRate;
        spawnTime = Random.Range(spawnRate.x, spawnRate.y);
    }

    public void Update (float _dt) {
        timePassed += _dt;

        if (timePassed >= spawnTime) {
            float percentage = GV.SPAWN_PERCENTAGE[Random.Range(0, GV.SPAWN_PERCENTAGE.Count)];
            Transform start = MushroomManager.Instance.GetRandomAIMushroom();
            Transform end = MushroomManager.Instance.GetRandomPlayerMushroom();

            UnitsManager.Instance.SendAIUnits(start, end, percentage);

            timePassed = 0f;
            spawnTime = Random.Range(spawnRate.x, spawnRate.y);
        }
    }
}
