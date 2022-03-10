using UnityEngine;

public class EnemyChasingState : EnemyState
{
    Transform target;
    float detectRadius;

    public EnemyChasingState(EnemyModel enemyModel, EnemyView enemyView) : base(enemyModel, enemyView)
    {}

    public override void OnEnterState(){
        base.OnEnterState();
    }

    public override void Tick(float chaseRadius){
        this.detectRadius = chaseRadius;
        detectObjectNearBy();
        tankMovement();
        tankRotation();
    }

    void tankMovement(){
        if(Vector3.Distance(this.enemyView.transform.position, target.position) > 4f){
            this.enemyView.transform.position = Vector3.MoveTowards(this.enemyView.transform.position, target.position, this.enemyModel.movementSpeed * Time.deltaTime);
        }
    }

    void detectObjectNearBy(){
        Collider[] colliders = Physics.OverlapSphere(this.enemyView.transform.position, this.detectRadius);
        if(colliders.Length > 0){
            for(int i=0; i<colliders.Length; i++){
                if(colliders[i].GetComponent<TankView>() != null){
                    target = colliders[i].transform;
                    break;
                }
            }
        }
    }

    void tankRotation(){
        this.enemyView.transform.LookAt(target);
    }

}
