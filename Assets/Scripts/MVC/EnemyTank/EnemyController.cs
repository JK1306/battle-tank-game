using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;

    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        this.enemyModel = enemyModel;
        this.enemyView = GameObject.Instantiate<EnemyView>(enemyView);
        this.enemyView.applyMaterial(this.enemyModel.applyMaterial);
    }

    public void reduceHealth(float damageTaken){
        if(enemyModel.health - damageTaken <= 0){
            GameObject.Destroy(this.enemyView.gameObject);
        }else{
            enemyModel.health -= damageTaken;
        }
    }
}
