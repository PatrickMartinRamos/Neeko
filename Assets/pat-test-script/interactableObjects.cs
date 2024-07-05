using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObjects : MonoBehaviour
{
    /// <summary>
    /// Handle Interactable Objects Data
    /// Handle checker for shadow and water puddles
    /// </summary>

    private catActionScript _catActionScript;
    private catController _catControllerScript;
    private npcManager _npcManager;
    public Transform playerTransform;
    public PlayerStatusScriptable playerStatus;
    
    //public var
    public LayerMask puddleMask;
    public LayerMask shadowMask;
    public LayerMask puzzleObjectsMask;
    public LayerMask NPCLayerMask;

    private void Awake()
    {
        _catActionScript = FindObjectOfType<catActionScript>();
        _catControllerScript = FindObjectOfType<catController>();
    }

    private void Update()
    {
        puddleCheck();
        shadowCheck();
        dragPuzzleObject();
        //puzzleObjectCheck();
        //NPCInteractions();
    }

    #region check if player is inside the puddle
    void puddleCheck()//check player if inside the water puddle
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position,_catActionScript.interactRadius, puddleMask);

        if (colliders.Length > 0)
        {
            _catActionScript.isInsidePuddle = true;
            Debug.Log("Player is inside the puddle!");
            playerStatus.PlayerStatus = status.withWater;
        }
        else
        {
            _catActionScript.isInsidePuddle = false;
            //Debug.Log("Player is not inside the puddle.");
            playerStatus.PlayerStatus = status.underSun;
        }
    }
    #endregion

    #region check if player is inside the shadow
    void shadowCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, _catActionScript.interactRadius, shadowMask);

        //lagay dto logic for shadow and sun interaction
        if (colliders.Length > 0)
        {
            _catActionScript.isInsideShadow = true;
            if(_catActionScript.isInsideShadow)
            {
                Debug.Log("Player is inside the shadow!");
                playerStatus.PlayerStatus = status.inShadow;
            }
        }
        else
        {
            _catActionScript.isInsideShadow = false;
            if(!_catActionScript.isInsideShadow)
            {
                Debug.Log("Player is not inside the shadow!");
                playerStatus.PlayerStatus = status.underSun;
            }
        }
    }
    #endregion

    #region check if player can interact with npcs
    //pass this to cat action script
    //if NPC layermask is inside the player radius of interaction do this logic
    //called by pressing "Q" key
    public void NPCInteractions()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, _catActionScript.interactRadius,NPCLayerMask);
        foreach (Collider collider in colliders)
        {
            npcScript npc = collider.GetComponent<npcScript>();//get npc script when near the npc
            if (npc != null)    
            {
                //can now interact with npc
                _catActionScript.isNPCInteractable = true;
                //flag the npcScript canStartNPCEvent that if this logic is called start moving
                npc.canStartNPCEvent(true); 
            }
        }
        if (colliders.Length == 0)
        {
            //make the npc not interactable
            _catActionScript.isNPCInteractable = false;
        }
    }
    #endregion

    #region drag puzzle object
    public void dragPuzzleObject()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position, _catActionScript.interactRadius, puzzleObjectsMask);

        if (colliders.Length > 0)
        {
            _catActionScript.canDragObject = true;
            GameObject puzzleObject = colliders[0].gameObject;

            if (_catActionScript.canDragObject && _catActionScript.isDragginObject)
            {
                Vector3 newPosition = playerTransform.position + playerTransform.forward * 2f;

                puzzleObject.transform.position = newPosition;
                puzzleObject.GetComponent<Rigidbody>().isKinematic = true;
                //Debug.Log("object is being drag " + puzzleObject.name);
            }
            else if(!_catActionScript.isDragginObject)
            {
                puzzleObject.GetComponent<Rigidbody>().isKinematic = false;
                //Debug.Log("Object is not being drag");
            }
        }
        else
        {
            _catActionScript.canDragObject = false;
        }
    }
    #endregion

}
