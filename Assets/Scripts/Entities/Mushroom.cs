using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    [Range(1, 4)]
    public int level = 1;
    public float units = 0;

    float timePassed = 0f;

    public void MushroomUpdate (float _dt) {
        timePassed += _dt;

        if (units < GV.MUSHROOM_MAX_UNIT * level && timePassed * level >= GV.UNIT_SPAWN_RATE) {
            units += 1;
            timePassed = 0f;

            Debug.Log(units);
        }
    }

}
