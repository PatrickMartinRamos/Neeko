using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class NPCLogic
{
    public GameObject NPCPrefab;
    public Transform targetPosition;
    [SerializeField] private float npcMovepeed;
    public float NpcMovepeed => npcMovepeed;
    public bool isUsingUmbrella = false;
}

public class npcManager : MonoBehaviour
{
    public List<NPCLogic> NPC;
    private npcScript _npcScript;
    private catActionScript _catActionScript;
    private void Awake()
    {
        _catActionScript = FindObjectOfType<catActionScript>();
        _npcScript = FindObjectOfType<npcScript>();

    }
    private void Start()
    {
        AssignTargetPositions();
        AssignSpeedToNPC();
    }
    private void Update()
    {
        
    }
    public void AssignTargetPositions()
    {
        for (int i = 0; i < NPC.Count; i++)
        {
            NPCLogic npc = NPC[i];
            npc.NPCPrefab.GetComponent<npcScript>().setTargetNPCPos(npc.targetPosition);
        }
    }

    public void AssignSpeedToNPC()
    {
        for(int i = 0; i < NPC.Count; i++)
        {
            NPCLogic npc = NPC[i];
            npc.NPCPrefab.GetComponent<npcScript>().setNPCSpeed(npc.NpcMovepeed);
        }
    }
}