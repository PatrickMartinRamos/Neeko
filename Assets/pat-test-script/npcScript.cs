using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{

    private npcManager _npcManager;
    private Transform targetPOS;
    private float moveSpeed;
    private Rigidbody _rb;
    private bool npcStartMoving = false;
    private Animator animator;

    private void Awake()
    {
        _npcManager = FindObjectOfType<npcManager>();
        animator = GetComponentInChildren<Animator>();
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
       //_rb.velocity = Vector3.zero;
    }

    public void setNPCSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void setTargetNPCPos(Transform target)
    {
        targetPOS = target;
    }

    public void startNPCEvent(bool startWalking)
    {
        npcStartMoving = startWalking;
    }

    void walkNPC()
    {
        if(npcStartMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPOS.position.x, transform.position.y, targetPOS.position.z), moveSpeed * Time.deltaTime);
            //transform.LookAt(targetPOS);
            animator.SetBool("IsWalking", true);
            Debug.DrawLine(transform.position, targetPOS.position, Color.red);
        }
        if(transform.position == new Vector3(targetPOS.position.x, transform.position.y,transform.position.z))
        {
            animator.SetBool("IsWalking", false);
        }
        
    }
}
