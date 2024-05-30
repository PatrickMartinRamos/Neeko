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
    public Transform playerTransform;


    //public var
    public LayerMask puddleMask;
    public LayerMask shadowMask;
    public LayerMask puzzleObjectsMask;

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
       // puzzleObjectCheck();
    }

    #region check if player is inside the puddle
    void puddleCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(playerTransform.position,_catActionScript.interactRadius, puddleMask);

        if (colliders.Length > 0)
        {
            _catActionScript.isInsidePuddle = true;
            //Debug.Log("Player is inside the puddle!");
        }
        else
        {
            _catActionScript.isInsidePuddle = false;
            //Debug.Log("Player is not inside the puddle.");
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
                //Debug.Log("Player is inside the shadow!");
            }
        }
        else
        {
            _catActionScript.isInsideShadow = false;
            if(!_catActionScript.isInsideShadow)
            {
                //Debug.Log("Player is not inside the shadow!");
            }
        }
    }
    #endregion

    //#region check if player can interact with the puzzle object
    //void puzzleObjectCheck()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(playerTransform.position, _catActionScript.interactRadius, puzzleObjectsMask);

    //    if(colliders.Length > 0)
    //    {
    //        _catActionScript.canDragObject = true;
    //    }
    //    else
    //    {
    //        _catActionScript.canDragObject = false;
    //    }
    //}
    //#endregion

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
}
