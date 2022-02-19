using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float health;
    public float movementSpeed;
    public TankModel(PlayerTankScriptableObject player){
        this.movementSpeed = player.movementSpeed;
        this.health = player.health;
    }
}
