using UnityEngine;

// [System.Serializable]
public class EnemyAttackingState : EnemyState
{
    Transform target;
    float radius;
    float waitTime = 7f;
    float cloak=0f;
    bool attackStateEnabled;

    public EnemyAttackingState(EnemyModel enemyModel, EnemyView enemyView) : base(enemyModel, enemyView)
    {
        attackStateEnabled = false;
        this.stateType = EnemyStateType.Attacking;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void Tick(float chaseRadius){
        this.radius = chaseRadius;
        detectObjectNearBy();
        tankRotation();
        firePlayer();
    }

    void firePlayer(){
        if(cloak >= waitTime || !attackStateEnabled){
            this.enemyView.fireShell();
            cloak = 0f;
            attackStateEnabled = true;
        }
        cloak += 0.1f;
    }

    void detectObjectNearBy(){
        Collider[] colliders = Physics.OverlapSphere(this.enemyView.transform.position, this.radius);
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
