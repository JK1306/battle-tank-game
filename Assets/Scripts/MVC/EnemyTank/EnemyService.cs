using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonBehaviour<EnemyService>
{
    public EnemyScriptableObjectsMaster enemyScriptableObjectsMaster;
    EnemyModel enemyModel;
    EnemyController enemyController;

    private void Start() {
        enemyModel = new EnemyModel(
            (EnemyScriptbleObject) enemyScriptableObjectsMaster.enemyScriptbleObjects.selectRandom()
        );
        enemyController = new EnemyController(enemyModel, enemyScriptableObjectsMaster.enemyView);
    }

    public void takeDamage(float damagePower){
        enemyController.reduceHealth(damagePower);
    }
}
