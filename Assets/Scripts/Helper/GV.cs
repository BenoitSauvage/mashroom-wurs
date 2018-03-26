using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV {
	
    // UNIT
    public static readonly float UNIT_TRAVEL_TIME = 2f;
    public static readonly float UNIT_SPAWN_RATE = 1f;
    public static readonly float UNIT_SEND_INTERVAL = .1f;
    public static readonly string UNIT_PLAYER_TAG = "PlayerUnit";
    public static readonly string UNIT_AI_TAG = "AIUnit";

    // MUSHROOM
    public enum MUSHROOM_TYPE { PLAYER, AI };
    public enum MUSHROOM_HOUSE_TYPE { MUSHROOM, FORGE };
    public static readonly string MUSHROOM_TAG_PLAYER = "PlayerMushroom";
    public static readonly string MUSHROOM_TAG_AI = "AIMushroom";
    public static readonly int MUSHROOM_MAX_UNIT = 20;

    // FORGE
    public static readonly string MUSHROOM_TAG_PLAYER_FORGE = "PlayerForge";
    public static readonly string MUSHROOM_TAG_AI_FORGE = "AIForge";
    public static readonly int FORGE_DAMAGE_MULTIPLIER = 2;

    // AI
    public static readonly List<float> SPAWN_PERCENTAGE = new List<float>(){ .1f, .25f, .5f, .75f, 1f };

    // OTHER
    public static readonly string GAME_OVER_SCENE = "GameOver";
}
