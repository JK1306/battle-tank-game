using UnityEngine;

public class EnemyPatrollingState : EnemyState
{
    Transform targetPosition;
    Vector3 tankMove;

    public EnemyPatrollingState(EnemyModel enemyModel, EnemyView enemyView) : base(enemyModel, enemyView){}

    public override void OnEnterState() {
        base.OnEnterState();
        targetPosition = this.enemyModel.patrolingPoints.selectRandomArr<Transform>();
    }
    
    public override void Tick(float radius=0) {
        tankRotation();
        tankMovement();
    }

    void tankMovement(){
        tankMove = Vector3.MoveTowards(this.enemyView.transform.position, targetPosition.position, this.enemyModel.movementSpeed * Time.deltaTime);
        if(Vector3.Distance(this.enemyView.transform.position, targetPosition.position) > 1f){
            this.enemyView.transform.position = tankMove;
        }else{
            targetPosition = this.enemyModel.patrolingPoints.selectRandomArr<Transform>();
        }
    }

    void tankRotation(){
        this.enemyView.transform.LookAt(targetPosition);
    }
}
