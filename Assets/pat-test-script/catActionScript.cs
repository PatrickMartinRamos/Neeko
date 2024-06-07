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
    [HideInInspector] public bool isNPCInteractable = false;
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

    bool IsPlayerMoving()
    {
        bool moving = transform.position != previousPOS;

        previousPOS = transform.position;

        return moving;
    }

    public void puddleInteraction()
    {
        if(isInsidePuddle && !isPlayerMoving)
        {
            //Debug.Log("can interact");
        }
        else
        {
           // Debug.Log("can't interact");
        }
    }

    public void canDragPuzzleObject()
    {
       if(canDragObject)
       {
           _interActableObjects.dragPuzzleObject();
       }
    }
  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
