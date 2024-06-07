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

    private void Awake()
    {
        _npcScript = FindObjectOfType<npcScript>();
    }
    private void Start()
    {
        AssignTargetPositions();
        AssignSpeedToNPC();
    }
    private void Update()
    {
        foreach(NPCLogic npc in NPC)
        {
            //Debug.Log(npc.NPCPrefab.name + " is using umbrella: " + npc.isUsingUmbrella);
            //Debug.Log(npc.NPCPrefab.name + " speed is: " + npc.NpcMovepeed) ;
        }
    }

    public List<float> GetNPCMoveSpeeds()
    {
        List<float> speeds = new List<float>();
        foreach (NPCLogic npc in NPC)
        {
            speeds.Add(npc.NpcMovepeed);
        }
        return speeds;
    }
    public List<GameObject> GetNPCPrefab()
    {
        List<GameObject> NPCPrefab = new List<GameObject>();
        foreach (NPCLogic npc in NPC)
        {
            NPCPrefab.Add(npc.NPCPrefab.gameObject);
        }
        return NPCPrefab;
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