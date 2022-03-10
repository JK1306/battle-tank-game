using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyState
{
    public EnemyModel enemyModel;
    public EnemyView enemyView;

    public EnemyState(EnemyModel enemyModel, EnemyView enemyView){
        this.enemyModel = enemyModel;
        this.enemyView = enemyView;
    }
    public virtual void OnEnterState(){}

    public virtual void OnExitState(){}

    public virtual void Tick(float target=0f){}
}
