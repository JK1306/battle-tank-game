using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float damagePower;
    public float thrustApplied;
    public Material materialToApply;
    public BulletType bulletType;

    public BulletModel(BulletScriptableObject bulletScriptableObject){
        this.damagePower = bulletScriptableObject.damage;
        this.bulletType = bulletScriptableObject.bulletType;
        this.materialToApply = bulletScriptableObject.material;
        this.thrustApplied = bulletScriptableObject.thrust;
    }
}

public enum BulletType{
    TankShell,
}