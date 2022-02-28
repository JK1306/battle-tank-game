using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float movementSpeed;
    public float health;
    public Material applyMaterial;
    public Transform[] patrolingPoints;

    public EnemyModel(EnemyScriptbleObject enemyScriptbleObject){
        this.movementSpeed = enemyScriptbleObject.movementSpeed;
        this.health = enemyScriptbleObject.health;
        this.applyMaterial = enemyScriptbleObject.appliedMaterial;
    }

    public void setPatrolingPoints(Transform[] patrolingPoints){
        this.patrolingPoints = patrolingPoints;
    }
}
