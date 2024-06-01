using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
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
    public HeatPointsScriptable playerHeatPt;
    private bool canIncrease=true;
    // Start is called before the first frame update
    void Start()
    {
        heatBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
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

    }

    IEnumerator IncreaseHP(float increment)
    {
        canIncrease = false;
        heatBar.value += increment;
        playerHeatPt.heatPoints = heatBar.value;
        yield return new WaitForSeconds(1);
        canIncrease = true;
    }

}
