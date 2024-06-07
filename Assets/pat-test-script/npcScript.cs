using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{

    private npcManager _npcManager;
    private Transform targetPOS;
    private float moveSpeed;

    private void Awake()
    {
        _npcManager = FindObjectOfType<npcManager>();
    }

    private void Start()
    {
        //setTargetNPCPos(targetPOS);
        //setNPCSpeed();
    }

    private void Update()
    {
        walkNPC();
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
        transform.position = Vector3.MoveTowards(transform.position, targetPOS.position,moveSpeed* Time.deltaTime);
    }
}
