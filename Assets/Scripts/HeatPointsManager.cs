using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum status
{
    inShadow,
    underSun,
    withWater
};
public class HeatPointsManager : MonoBehaviour
{
    private Slider heatBar;
    private float increment = 0;
    [SerializeField] private status playerStatus;
    public BarValuesScriptable playerHeatPt;
    public PlayerStatusScriptable playerCondition;
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
        switch (playerStatus)
        {
            case status.inShadow:
                increment = -2;
                break;
            case status.underSun:
                increment = 5;
                break;
            case status.withWater:
                increment = 2;
                break;
            default:
                break;
        }
        if(canIncrease)
        StartCoroutine(IncreaseHP(increment));

        if(playerHeatPt.Amount == 100)
        {
            SceneManager.LoadScene(0);
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
