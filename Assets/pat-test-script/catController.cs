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
    private InteractUI _interactUI;

    private Vector2 walkAction;

    //public Subject<bool> TestSubject;
    //private interactableObjects _interactableObjects;
    #region start/update/awake
    private void Awake()
    {
        _playerInputs = new PlayerInputEditor();
        _catMoveScript = GetComponent<catMoveScript>();
        _catActionScript = GetComponent<catActionScript>();
        _interactUI = FindObjectOfType<InteractUI>();

        //_interactableObjects = GetComponent<interactableObjects>();
    }

    private void Update()
    {
        //if (walkAction != Vector2.zero)
        //{
        //    _catMoveScript.walkMotionWASD(walkAction);
        //}
    }
    #endregion

    #region enable/disable input action
    private void OnEnable()
    {
        _playerInputs.Enable();

        _playerInputs.playerMovements.walkingWASD.performed += ctx => walkAction = ctx.ReadValue<Vector2>();
        _playerInputs.playerMovements.walkingWASD.canceled += ctx => walkAction = Vector2.zero;

        //_playerInputs.playerMovements.Walk.performed += WalkInput;
        //_playerInputs.playerMovements.Walk.canceled += WalkInput;

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

        _playerInputs.playerMovements.walkingWASD.performed -= ctx => walkAction = ctx.ReadValue<Vector2>();
        _playerInputs.playerMovements.walkingWASD.canceled -= ctx => walkAction = Vector2.zero;

        //_playerInputs.playerMovements.Walk.performed -= WalkInput;
        //_playerInputs.playerMovements.Walk.canceled -= WalkInput;

        _playerInputs.playerMovements.Interact.performed -= interactInput;
        _playerInputs.playerMovements.Interact.canceled -= interactInput;

        _playerInputs.playerMovements.dragObject.performed -= dragInput;
        _playerInputs.playerMovements.dragObject.canceled -= dragInput;

        _playerInputs.playerMovements.NPCInteract.performed -= NPCInteract;
        _playerInputs.playerMovements.NPCInteract.canceled -= NPCInteract;
    }
    #endregion

    //public void WalkInput(InputAction.CallbackContext context)
    //{
    //    _catMoveScript.WalkMotion();
    //}


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


       _interactUI.interactUIPrefab.SetActive(false);
        
    }

    public void NPCInteract(InputAction.CallbackContext context)
    {
        //if "Q" key is press it will call interactWithNPC
        _catActionScript.interactWithNPC();
    }

}
