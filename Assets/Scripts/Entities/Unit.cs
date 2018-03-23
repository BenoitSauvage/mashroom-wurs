using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour {

    public float startDelay = 0f;

    float life = 1f;
    float damage = 1f;

    NavMeshAgent agent;
    Transform destination;

    void Update() {
        transform.eulerAngles = new Vector3(90, 0, 0);
	}

	public void Init () {
        transform.eulerAngles = new Vector3(90, 0, 0);
        agent = GetComponent<NavMeshAgent>();  
    }

    public void UpdateDestination (Transform _destination) {
        destination = _destination;
        agent.SetDestination(destination.position);
    }

    public bool IsArrived () {
        if (destination)
            return Vector3.Distance(agent.transform.position, destination.transform.position) <= agent.stoppingDistance;

        return false;
    }
}
