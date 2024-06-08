using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBarManager : MonoBehaviour
{
    private Slider waterBar;
    private float increment = 0;
    [SerializeField] private status playerStatus;
    public BarValuesScriptable playerWaterDrop;
    private bool canIncrease = true;
    // Start is called before the first frame update
    void Awake()
    {
        waterBar = GetComponent<Slider>();
        playerWaterDrop.Amount = 0;
        waterBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerStatus)
        {
            case status.inShadow:
                increment = -1f;
                break;
            case status.underSun:
                increment = -3f;
                break;
            default:
                break;
        }
        if (canIncrease)
            StartCoroutine(IncreaseHP(increment));

    }

    IEnumerator IncreaseHP(float increment)
    {
        canIncrease = false;
        //heatBar.value = Mathf.Lerp(heatBar.value)
        playerWaterDrop.Amount = Mathf.Clamp(playerWaterDrop.Amount+increment, 0, 100); ;
        waterBar.value = playerWaterDrop.Amount;
        yield return new WaitForSeconds(1);
        canIncrease = true;
    }

}
