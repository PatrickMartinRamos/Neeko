using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catActionScript : MonoBehaviour
{

    /// <summary>
    /// Handle Player Interaction to Objects
    /// </summary>

    //system var
    public static catActionScript instance; 

    public float interactRadius;
    [HideInInspector] public bool isInsidePuddle = false;
    [HideInInspector] public bool isInsideShadow = false;
    [HideInInspector] public bool isPlayerMoving = false;
    [HideInInspector] public bool canDragObject = false;
    [HideInInspector] public bool isDragginObject = false;
     public bool isNPCInteractable = false;
    private Vector3 previousPOS;

    private interactableObjects _interActableObjects;

    private void Awake()
    {

        instance = this;
        _interActableObjects = FindObjectOfType<interactableObjects>();
    }
    private void Start()
    {
        previousPOS = transform.position;
    }

    private void Update()
    {
        isPlayerMoving = IsPlayerMoving();
    }

    bool IsPlayerMoving()//check if player is moving
    {
        bool moving = transform.position != previousPOS;

        previousPOS = transform.position;

        return moving;
    }

    public void puddleInteraction()
    {
        //player can only interact if not moving 
        if(isInsidePuddle && !isPlayerMoving)
        {
            //lagay dito for water puddle interaction
            //Debug.Log("can interact");
        }
        else
        {
            //Debug.Log("can't interact");
        }
    }

    public void canDragPuzzleObject()
    {
       if(canDragObject)
       {
           _interActableObjects.dragPuzzleObject();
       }
    }

    public void interactWithNPC()
    {
        //get NPCInteraction logic and pass it to NPC interact in catController
        _interActableObjects.NPCInteractions();
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
