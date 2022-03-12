using System;
using UnityEngine;
using UnityEngine.UI;

public class TankServices : SingletonBehaviour<TankServices>
{
    public PlayerTankMasterScriptableObjects playerTankMasterScriptableObjects;
    public Joystick joystick;
    private TankController tankController;
    public event Action bulletFireNotification;
    public Action playerDeathNotification;
    public Action<float> playerTravelNotification; 
    void Start()
    {
        tankController = new TankController(playerTankMasterScriptableObjects.tankView, joystick, (PlayerTankScriptableObject)playerTankMasterScriptableObjects.playerTankScriptableObjects.selectRandom());
    }

    public void takeDamage(float damageTaken){
        tankController.reduceHealth(damageTaken);
    }

    public void notifyBulletFireAchievement(){
        bulletFireNotification?.Invoke();        
    }

    public void notifyOnPlayerDeath(){
        playerDeathNotification?.Invoke();
    }

    public void notifyOnTraveled5m(float traveledDistance){
        playerTravelNotification?.Invoke(traveledDistance);
    }
}
