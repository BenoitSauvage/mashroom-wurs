using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV {
	
    // UNIT
    public static readonly float UNIT_TRAVEL_TIME = 2f;
    public static readonly float UNIT_SPAWN_RATE = 1f;
    public static readonly float UNIT_SEND_INTERVAL = .1f;

    // MUSHROOM
    public static readonly int MUSHROOM_MAX_UNIT = 20;

    // AI
    public static readonly List<float> SPAWN_PERCENTAGE = new List<float>(){ .1f, .25f, .5f, .75f, 1f };
}
