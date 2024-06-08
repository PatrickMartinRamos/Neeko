using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{

    private npcManager _npcManager;
    private Transform targetPOS;
    private float moveSpeed;
    private Rigidbody _rb;

    private void Awake()
    {
        _npcManager = FindObjectOfType<npcManager>();
    }

    private void Start()
    {
        //setTargetNPCPos(targetPOS);
        //setNPCSpeed();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        walkNPC();

        _rb.velocity = Vector3.zero;
    }

    public void setNPCSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void setTargetNPCPos(Transform target)
    {
        targetPOS = target;
    }

    void walkNPC()
    {
        //create event kung mag interacti si player start moving na ung npc
        transform.position = Vector3.MoveTowards(transform.position, targetPOS.position,moveSpeed* Time.deltaTime);
    }
}
