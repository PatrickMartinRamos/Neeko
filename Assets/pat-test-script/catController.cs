using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class catController : MonoBehaviour
{
    /// <summary>
    /// Handle Player Inputs
    /// </summary>

    private PlayerInputEditor _playerInputs;
    private catMoveScript _catMoveScript;
    private catActionScript _catActionScript;

    public Subject<bool> TestSubject;


    //private interactableObjects _interactableObjects;

    private void Awake()
    {
        _playerInputs = new PlayerInputEditor();
        _catMoveScript = GetComponent<catMoveScript>();
        _catActionScript = GetComponent<catActionScript>();

        //_interactableObjects = GetComponent<interactableObjects>();
    }

    #region enable/disable input action
    private void OnEnable()
    {
        _playerInputs.Enable();

        _playerInputs.playerMovements.Walk.performed += WalkInput;
        _playerInputs.playerMovements.Walk.canceled += WalkInput;

        _playerInputs.playerMovements.Interact.performed += interactInput;
        _playerInputs.playerMovements.Interact.canceled += interactInput;

        _playerInputs.playerMovements.dragObject.performed += dragInput;
        _playerInputs.playerMovements.dragObject.canceled += dragInput;

        _playerInputs.playerMovements.NPCInteract.performed += NPCInteract;
        _playerInputs.playerMovements.NPCInteract.canceled += NPCInteract;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();

        _playerInputs.playerMovements.Walk.performed -= WalkInput;
        _playerInputs.playerMovements.Walk.canceled -= WalkInput;

        _playerInputs.playerMovements.Interact.performed -= interactInput;
        _playerInputs.playerMovements.Interact.canceled -= interactInput;

        _playerInputs.playerMovements.dragObject.performed -= dragInput;
        _playerInputs.playerMovements.dragObject.canceled -= dragInput;

        _playerInputs.playerMovements.NPCInteract.performed -= NPCInteract;
        _playerInputs.playerMovements.NPCInteract.canceled -= NPCInteract;
    }
    #endregion

    public void WalkInput(InputAction.CallbackContext context)
    {
        _catMoveScript.WalkMotion();
    }

    public void interactInput(InputAction.CallbackContext context)
    {
        //button para sa pag interact sa object
        _catActionScript.puddleInteraction();
    }

    public void dragInput(InputAction.CallbackContext context)
    {
        //button for dragging puzzle objects
        _catActionScript.canDragPuzzleObject();
       _catActionScript.isDragginObject = !_catActionScript.isDragginObject;
    }

    public void NPCInteract(InputAction.CallbackContext context)
    {

    }

}
