using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcScript : MonoBehaviour
{
    private npcManager _npcManager;
    private Transform targetPOS;
    private float moveSpeed;
    private NavMeshAgent _navMeshAgent;
    private Animator animator;
    public bool npcStartMoving = false;


    private void Awake()
    {
        _npcManager = FindObjectOfType<npcManager>();
        animator = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (npcStartMoving)
        {
            //move this npc using navmesh set destination then target position is assigned by npc manager
            _navMeshAgent.SetDestination(new Vector3(targetPOS. position.x, transform.position.y, targetPOS.position.z  ));
            animator.SetBool("IsWalking", true);
        }

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.magnitude == 0f)
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
    //use speed assign in npc manager
    public void setNPCSpeed(float speed)
    {
        _navMeshAgent.speed = speed;
    }
    //use target position assign in the npc manager
    public void setTargetNPCPos(Transform target)
    {
        targetPOS = target;
    }

    public void canStartNPCEvent(bool startWalking)
    {
        //if NPCInteractions is called in interactableObject start the NPC movement
        npcStartMoving = startWalking;
    }
}
