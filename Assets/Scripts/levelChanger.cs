using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class levelChanger : MonoBehaviour
{
    [SerializeField]private level currentLevel;
    private audioManager _audioManagerInstance;
    private void Awake()
    {
        _audioManagerInstance = audioManager.instance;
        Debug.Log(_audioManagerInstance != null ? "AudioManager instance found." : "AudioManager instance is null.");
    }
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
        if (_audioManagerInstance != null)
        {
            _audioManagerInstance.Play("LevelSFX");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null, cannot play sound");
        }
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
