using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonBehaviour<EnemyService>
{
    public EnemyScriptableObjectsMaster enemyScriptableObjectsMaster;
    public Transform[] patrolingPoints;
    EnemyModel enemyModel;
    EnemyController enemyController;

    private void Start() {
        enemyModel = new EnemyModel(
            (EnemyScriptbleObject) enemyScriptableObjectsMaster.enemyScriptbleObjects.selectRandom()
        );
        enemyModel.setPatrolingPoints(patrolingPoints);
        enemyController = new EnemyController(enemyModel, enemyScriptableObjectsMaster.enemyView);
    }

    public void takeDamage(float damagePower){
        enemyController.reduceHealth(damagePower);
    }
}
