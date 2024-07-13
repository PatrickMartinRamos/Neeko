using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum status
{
    inShadow,
    underSun,
    withWater,
    inWater
};
public class HeatPointsManager : MonoBehaviour
{
    private Slider heatBar;
    private float increment = 0;
    [SerializeField] private status playerStatus;
    [SerializeField] private BarValuesScriptable playerHeatPt;
    [SerializeField] private PlayerStatusScriptable playerCondition;
    private bool canIncrease=true;
    // Start is called before the first frame update
    void Awake()
    {
        heatBar = GetComponent<Slider>();
        playerHeatPt.Amount = 0;
        heatBar.value= 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerStatus = playerCondition.PlayerStatus;
        level playerLevel = playerCondition.PlayerLevel;
        switch (playerStatus)
        {
            case status.inShadow:
                increment = -3;
                break;
            case status.underSun:
                increment = 5;
                break;
            case status.withWater:
                increment = 2;
                break;
            case status.inWater:
                increment = 0;
                break;
            default:
                break;
        }
        if (canIncrease)
        {
            switch (playerLevel)
            {
                case level.one:
                    StartCoroutine(IncreaseHP(increment));
                    break;
                case level.two:
                    increment = increment > 0 ? increment *= 1.5f : increment *= 0.8f;
                    StartCoroutine(IncreaseHP(increment));
                    break;
                case level.three:
                    increment = increment > 0 ? increment *= 2f : increment *= 0.5f;
                    StartCoroutine(IncreaseHP(increment));
                    break;
                default: break;
            }
        }
        

        if(playerHeatPt.Amount == 100)
        {
            playerCondition.causeDeath = 2;
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator IncreaseHP(float increment)
    {
        canIncrease = false;
        //heatBar.value = Mathf.Lerp(heatBar.value)
        playerHeatPt.Amount = Mathf.Clamp(playerHeatPt.Amount+increment,0,100);
        heatBar.value = playerHeatPt.Amount;
        yield return new WaitForSeconds(1);
        canIncrease = true;
    }
}
