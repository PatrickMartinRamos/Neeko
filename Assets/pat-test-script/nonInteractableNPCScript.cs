using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nonInteractableNPCScript : MonoBehaviour
{
    public List<Transform> destinations;
    private NavMeshAgent navMeshAgent;
    private int currentDestinationIndex = 0;
    private bool isGoingForward = true;
    private float npcSpeed;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (destinations.Count > 0)
        {
            SetDestination(destinations[currentDestinationIndex]);
        }
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < 0.1f && !navMeshAgent.pathPending)
        {           
            if (isGoingForward)
            {
                currentDestinationIndex++;
                if (currentDestinationIndex >= destinations.Count)
                {
                    currentDestinationIndex = destinations.Count - 2 ; // Move back to the second last destination
                    isGoingForward = false;
                }
            }
            else
            {
                currentDestinationIndex--;
                if (currentDestinationIndex < 0)
                {
                    currentDestinationIndex = 0; // Move forward to the second destination
                    isGoingForward = true;
                }
            }

            SetDestination(destinations[currentDestinationIndex]);
        }
    }
    //use target position assign in the npc manager
    public void SetDestination(Transform destination)
    {
        navMeshAgent.SetDestination(destination.position);
    }
    //use speed assign in npc manager
    public void setNonInteractableNPCSpeed(float speed)
    {
        navMeshAgent.speed = speed;
    }
}
