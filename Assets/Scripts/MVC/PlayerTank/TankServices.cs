using UnityEngine;
using UnityEngine.UI;

public class TankServices : SingletonBehaviour<TankServices>
{
    public PlayerTankMasterScriptableObjects playerTankMasterScriptableObjects;
    public Joystick joystick;
    private TankController tankController;
    void Start()
    {
        tankController = new TankController(playerTankMasterScriptableObjects.tankView, joystick, (PlayerTankScriptableObject)playerTankMasterScriptableObjects.playerTankScriptableObjects.selectRandom());
    }
}
