﻿using UnityEngine;

public class TankController
{
    public TankModel tankModel;
    public TankView tankView;
    public TankController(TankView tankView, Joystick joystick, PlayerTankScriptableObject playerTankScriptableObject){
        this.tankModel = new TankModel(playerTankScriptableObject);
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        this.tankView.setupJoyStick(joystick);
        this.tankView.setTankController(this);
    }

    public void tankMovement(float horizontal, float vertical){
        Vector3 currentPosition = this.tankView.transform.position;
        if(Input.touchCount > 0){
            currentPosition.x += (horizontal * Time.deltaTime) * this.tankModel.movementSpeed;
            currentPosition.z += (vertical * Time.deltaTime) * this.tankModel.movementSpeed;
        }
        this.tankView.transform.position = currentPosition;
    }

    public void fireBullet(Transform bulletSpawnPosition)
    {
        BulletService.Instance.fireBullet(tankModel.bulletType, bulletSpawnPosition, BulletParent.Player);
    }

    public void playerRotation(float horizontal, float vertical){
        if(vertical != 0 || horizontal != 0){
            Vector3 currentPosition = this.tankView.transform.position;
            Vector3 tankRotation = new Vector3(
                    horizontal,
                    0f,
                    Mathf.Abs(vertical)
                );
            tankRotation = tankRotation.normalized;
            this.tankView.transform.forward = tankRotation;
        }
    }

    public void reduceHealth(float damageTaken){
        if(tankModel.health - damageTaken <= 0){
            GameObject.Destroy(this.tankView.gameObject);
        }else{
            tankModel.health -= damageTaken;
        }
    }
}