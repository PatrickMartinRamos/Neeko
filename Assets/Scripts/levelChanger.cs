using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChanger : MonoBehaviour
{
    [SerializeField]private level currentLevel;
    // Start is called before the first frame update
    public void ChangeLevel(PlayerStatusScriptable playerStatus)
    {
        playerStatus.PlayerLevel = currentLevel;
        playerStatus.playerHeatPt.Amount = 0;
    }

}
