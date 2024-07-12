using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class levelChanger : MonoBehaviour
{
    [SerializeField]private level currentLevel;
    // Start is called before the first frame update
    public void Start()
    {
        if(currentLevel == level.three)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        FountainDogsManager.onFountainQuestComplete.AddListener(enableCheckpoint);
    }
    public void ChangeLevel(PlayerStatusScriptable playerStatus)
    {
        playerStatus.PlayerLevel = currentLevel;
        playerStatus.playerHeatPt.Amount = 0;
    }
    void enableCheckpoint()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(focusCam());
    }
    IEnumerator focusCam()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        transform.GetChild(1).gameObject.SetActive(false);
    }

}
