using UnityEngine;

[CreateAssetMenu(fileName = "Scriptables", menuName = "PlayerStatus")]
public class PlayerStatusScriptable : ScriptableObject
{
    public BarValuesScriptable playerWaterDrop;
    public status PlayerStatus;
}
