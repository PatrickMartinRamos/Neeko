using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class NPCLogic
{
    public GameObject NPCPrefab;
    public Transform targetPosition;
    [SerializeField] private float npcMovepeed;
    public float NpcMovepeed => npcMovepeed;
}

[System.Serializable]
public class NonInteractableNPC
{
    public GameObject nonIntNPCPrefab;
    public List<Transform> destinationPoint;
    [SerializeField] private float nonIntNPCSpeed;
    public float NonIntNPCSpeed => nonIntNPCSpeed;
}

public class npcManager : MonoBehaviour
{
    public List<NPCLogic> NPC;
    public List<NonInteractableNPC> nonInteractableNPCs;

    private npcScript _npcScript;
    private catActionScript _catActionScript;

    #region start/update/awake
    private void Awake()
    {
        _catActionScript = FindObjectOfType<catActionScript>();
        _npcScript = FindObjectOfType<npcScript>();

    }
    private void Start()
    {
        AssignTargetPositions();
        AssignSpeedToNPC();
        AssignNonInteractableNPCDestinations();
        AssignSpeedToNonInteractableNPC();
    }
    #endregion

    #region AssignTargetPositions
    public void AssignTargetPositions()
    {
        //for (int i = 0; i < NPC.Count; i++)
        //{
        //    NPCLogic npc = NPC[i];
        //    npc.NPCPrefab.GetComponent<npcScript>().setTargetNPCPos(npc.targetPosition);
        //}

        foreach (var npc in NPC)
        {
            npc.NPCPrefab.GetComponent<npcScript>().setTargetNPCPos(npc.targetPosition);
        }
    }
    #endregion

    #region AssignSpeedToNPC
    public void AssignSpeedToNPC()
    {
        //for(int i = 0; i < NPC.Count; i++)
        //{
        //    NPCLogic npc = NPC[i];
        //    npc.NPCPrefab.GetComponent<npcScript>().setNPCSpeed(npc.NpcMovepeed);
        //}

        //assign each npc different speed
        foreach (var npc in NPC)
        {
            npc.NPCPrefab.GetComponent<npcScript>().setNPCSpeed(npc.NpcMovepeed);
        }
    }
    #endregion

    #region AssignNonInteractableNPCDestinations
    public void AssignNonInteractableNPCDestinations()
    {
        //set destination for each non interactable npcs
        foreach (var nonIntNPC in nonInteractableNPCs)
        {
            nonIntNPC.nonIntNPCPrefab.GetComponent<nonInteractableNPCScript>().destinations = nonIntNPC.destinationPoint;
        }
    }
    #endregion

    #region
    public void AssignSpeedToNonInteractableNPC()
    {
        //set speed for non interactable npc
       foreach(var nonIntNPC in nonInteractableNPCs)
        {
            nonIntNPC.nonIntNPCPrefab.GetComponent<nonInteractableNPCScript>().setNonInteractableNPCSpeed(nonIntNPC.NonIntNPCSpeed);
        }
    }
    #endregion
}