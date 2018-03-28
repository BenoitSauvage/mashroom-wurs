using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour {

    public float startDelay = 0f;
    public float damage = 1f;

    NavMeshAgent agent;
    Transform destination;

    void Update() {
        transform.eulerAngles = new Vector3(90, 0, 0);
    }

	public void Init () {
        agent = GetComponent<NavMeshAgent>();
    }

    public void UpdateDestination (Transform _destination) {
        destination = _destination;
        agent.SetDestination(destination.position);
    }

    void OnCollisionEnter(Collision coll)
    {
        if ((coll.gameObject.tag == "AIUnit" || coll.gameObject.tag == "PlayerUnit") && coll.gameObject.tag != gameObject.tag) {

            UnitsManager.Instance.RemoveCorps(gameObject, coll.gameObject);

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    public bool IsArrived () {
        if (destination)
            return Vector3.Distance(agent.transform.position, destination.transform.position) <= agent.stoppingDistance + .5f;

        return false;
    }
}
