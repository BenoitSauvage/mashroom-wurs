
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mushroom : House
{

    [Range(1, 4)]
    public int level = 1;

    float timePassed = 0f;
    SpriteRenderer sprite;

    private void Start()
    {
        house_type = GV.MUSHROOM_HOUSE_TYPE.MUSHROOM;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void MushroomUpdate(float _dt)
    {
        timePassed += _dt;

        if (units < GV.MUSHROOM_MAX_UNIT * level && timePassed * level >= GV.UNIT_SPAWN_RATE)
        {
            units += 1;
            labelOfUnits.text = "" + units;
            timePassed = 0f;
        }
    }

    public void SwitchTeam()
    {
        if (type == GV.MUSHROOM_TYPE.PLAYER)
        {
            type = GV.MUSHROOM_TYPE.AI;
            sprite.sprite = Resources.Load<Sprite>("Sprites/ai_champ");
            MushroomManager.Instance.SwitchTeam(transform, type, this);
            transform.name = "AIMushroom";
        }
        else
        {
            type = GV.MUSHROOM_TYPE.PLAYER;
            sprite.sprite = Resources.Load<Sprite>("Sprites/player_champ");
            MushroomManager.Instance.SwitchTeam(transform, type, this);
            transform.name = "PlayerMushroom";
        }
    }

}
