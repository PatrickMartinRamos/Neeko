using UnityEngine;

[CreateAssetMenu(fileName = "Scriptables", menuName = "PlayerStatus")]
public class PlayerStatusScriptable : ScriptableObject
{
    public BarValuesScriptable playerWaterDrop;
    public BarValuesScriptable playerHeatPt;
    public status PlayerStatus;
    public level PlayerLevel;
    public bool isRunning;
    [Range(1,3)] public int causeDeath;
    private void Awake()
    {
        isRunning= false;
        PlayerLevel = level.one;
    }
}

public enum level
{
    one,
    two,
    three
};