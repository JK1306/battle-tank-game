using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float health;
    public float movementSpeed;
    public BulletType bulletType;
    public Material applyMaterial;
    public Transform[] patrolingPoints;

    public EnemyModel(EnemyScriptbleObject enemyScriptbleObject){
        this.movementSpeed = enemyScriptbleObject.movementSpeed;
        this.health = enemyScriptbleObject.health;
        this.applyMaterial = enemyScriptbleObject.appliedMaterial;
        this.bulletType = enemyScriptbleObject.bulletType;
    }

    public void setPatrolingPoints(Transform[] patrolingPoints){
        this.patrolingPoints = patrolingPoints;
    }
}
