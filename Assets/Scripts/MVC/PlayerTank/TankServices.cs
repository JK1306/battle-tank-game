using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : SingletonBehaviour<TankServices>
{
    public PlayerTankMasterScriptableObjects playerTankMasterScriptableObjects;
    public float movementSpeed, health;
    private TankModel tankModel;
    private TankController tankController;
    void Start()
    {
        tankModel = new TankModel(
            (PlayerTankScriptableObject) playerTankMasterScriptableObjects.playerTankScriptableObjects.selectRandom()
        );
        this.movementSpeed = tankModel.movementSpeed;
        this.health = tankModel.health;
        tankController = new TankController(playerTankMasterScriptableObjects.tankView, tankModel);
    }
}
