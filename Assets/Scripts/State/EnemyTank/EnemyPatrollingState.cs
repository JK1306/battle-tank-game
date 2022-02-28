using UnityEngine;

public class EnemyPatrollingState : EnemyState
{
    Transform targetPosition;
    Vector3 tankMove;

    public override void OnEnterState(EnemyModel enemyModel) {
        base.OnEnterState(enemyModel);
        targetPosition = this.enemyModel.patrolingPoints.selectRandomArr<Transform>();
    }
    
    public override void Tick(float radius=0) {
        tankRotation();
        tankMovement();
    }

    void tankMovement(){
        tankMove = Vector3.MoveTowards(transform.position, targetPosition.position, this.enemyModel.movementSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition.position) > 1f){
            transform.position = tankMove;
        }else{
            targetPosition = this.enemyModel.patrolingPoints.selectRandomArr<Transform>();
        }
    }

    void tankRotation(){
        transform.LookAt(targetPosition);
    }
}
