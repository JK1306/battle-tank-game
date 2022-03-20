using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public float damagePower;
    public float thrustApplied;
    public Material materialToApply;
    public BulletType bulletType;
    public BulletParent bulletParent;
    public ParticleSystem shellExplosionPartical;

    public BulletModel(BulletScriptableObject bulletScriptableObject, BulletParent bulletParent){
        this.damagePower = bulletScriptableObject.damage;
        this.thrustApplied = bulletScriptableObject.thrust;
        this.bulletParent = bulletParent;
        this.bulletType = bulletScriptableObject.bulletType;
        this.materialToApply = bulletScriptableObject.material;
        this.shellExplosionPartical = bulletScriptableObject.shellExplosion;
    }

    public void SetBulletParent(BulletParent bulletParent){
        this.bulletParent = bulletParent;
    }
}

public enum BulletType{
    TankShell,
}

public enum BulletParent{
    Player,
    Enemy
}