using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    EnemyController enemyController;
    public EnemyModel enemyModel { get; private set;}
    public MeshRenderer Chassis,
                        TrackLeft,
                        TrackRight,
                        TankTurrent;
    public Transform firingPosition;                        

    // Enemy States
    public EnemyIdleState enemyIdleState;
    public EnemyPatrollingState enemyPatrollingState;
    public EnemyChasingState enemyChasingState;
    public EnemyAttackingState enemyAttackingState;
    public EnemyState currentState;

    public void applyMaterial(Material material){
        Chassis.material = material;
        TrackLeft.material = material;
        TrackRight.material = material;
        TankTurrent.material = material;
    }

    public void setupController(EnemyController enemyController, EnemyModel enemyModel){
        this.enemyController = enemyController;
        this.enemyModel = enemyModel;
        applyMaterial(enemyModel.applyMaterial);
    }

    public void fireShell(){
        this.enemyController.fire(firingPosition);
    }
}
