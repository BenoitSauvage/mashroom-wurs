using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
        switch (other.tag) {
            case "PlayerUnit":
                if (TryToKillUnit()) {
                    UnitsManager.Instance.RemoveUnit(other.transform, GV.MUSHROOM_TYPE.PLAYER);
                }
                break;
            case "AIUnit":
                if (TryToKillUnit()) {
                    UnitsManager.Instance.RemoveUnit(other.transform, GV.MUSHROOM_TYPE.AI);
                }
                break;
        }
	}

    private bool TryToKillUnit () {
        return Random.Range(0f, 10f) >= 8f;
    }
}
