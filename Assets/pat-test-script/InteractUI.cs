using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    private Transform playerPos; 
    private catActionScript _catActionScript;
    private npcScript _npcScript;
    public LayerMask UITriggerLayerMask;
    private string playerTag = "Player";
    public GameObject interactUIPrefab;

    private void Start()
    {
        _catActionScript = FindObjectOfType<catActionScript>();
        _npcScript = FindObjectOfType<npcScript>();
    }
    void Update()
    {
        showNPCInteractUI();
    }
    #region promot interact
    void showNPCInteractUI()
    {
        //find player using tag
        GameObject [] objectsWithTag = GameObject.FindGameObjectsWithTag(playerTag);
        //get player position
        playerPos = objectsWithTag[0].transform;

        Collider[] colliders = Physics.OverlapSphere(playerPos.position, _catActionScript.interactRadius, UITriggerLayerMask);

        if (colliders.Length > 0)
        {
            // Debug.Log("show UI");
            interactUIPrefab.SetActive(true);
            // Rotate UI prefab to look at player (y-axis rotation)
            Vector3 direction = playerPos.position - interactUIPrefab.transform.position;
            // Restrict rotation to the horizontal plane
            direction.y = 0f; 
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            interactUIPrefab.transform.rotation = Quaternion.Euler(-90f, targetRotation.eulerAngles.y, 0f);
        }
        else
        {
            interactUIPrefab.SetActive(false);
        }
        // Debug.Log(objectsWithTag[0].name);
    }
    #endregion

}
