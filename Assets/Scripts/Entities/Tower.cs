using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    LineRenderer line;

    private void Start() {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = 360;
        line.startWidth = .05f;
        line.useWorldSpace = false;

        float angle = 20f;

        for (int i = 0; i < line.positionCount; i++) {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * 4;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * 4;

            line.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / (line.positionCount - 1));
        }
	}

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
        return Random.Range(0, 10) >= 8;
    }
}
