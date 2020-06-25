using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        InitializePatrolRoute();


        MoveToNextPatrolRoute();
    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolRoute()
    {
        agent.destination = locations[locationIndex].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
