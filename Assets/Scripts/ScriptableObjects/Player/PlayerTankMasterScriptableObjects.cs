using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerTankMaster", menuName = "ScriptableObjects/PlayerTankMaster", order = 0)]
public class PlayerTankMasterScriptableObjects : ScriptableObject {
    public TankView tankView;
    public PlayerTankScriptableObject[] playerTankScriptableObjects;
}