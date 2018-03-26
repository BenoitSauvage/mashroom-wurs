using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour {

    [Range(1, 4)]
    public int level = 1;
    public float units = 0;
    public GV.MUSHROMM_TYPE type;

    float timePassed = 0f;
    SpriteRenderer sprite;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
	}

	public void MushroomUpdate (float _dt) {
        timePassed += _dt;

        if (units < GV.MUSHROOM_MAX_UNIT * level && timePassed * level >= GV.UNIT_SPAWN_RATE) {
            units += 1;
            timePassed = 0f;
        }
    }

    public void SwitchTeam () {
        if (type == GV.MUSHROMM_TYPE.PLAYER) {
            type = GV.MUSHROMM_TYPE.AI;
            sprite.sprite = Resources.Load<Sprite>("Sprites/ai_champ");
            MushroomManager.Instance.SwitchTeam(transform, type, this);
            transform.name = "AIMushroom";
        } else {
            type = GV.MUSHROMM_TYPE.PLAYER;
            sprite.sprite = Resources.Load<Sprite>("Sprites/player_champ");
            MushroomManager.Instance.SwitchTeam(transform, type, this);
            transform.name = "PlayerMushroom";
        }
    }

}
