using System.Collections;
using UnityEngine;

public class EnemyAttackingState : EnemyState
{
    Transform target;
    float radius;
    EnemyView enemyView;
    float waitTime = 10f;
    float cloak=0f;

    public override void OnEnterState(EnemyModel enemyModel)
    {
        base.OnEnterState(enemyModel);
        enemyView = GetComponent<EnemyView>();
    }

    public override void Tick(float chaseRadius){
        this.radius = chaseRadius;
        detectObjectNearBy();
        tankRotation();
        firePlayer();
    }

    void firePlayer(){
        if(cloak >= waitTime){
            enemyView.fireShell();
            cloak = 0f;
        }
        cloak += 0.1f;
        // StartCoroutine(spawnBullet());
    }

    IEnumerator spawnBullet(){
        yield return new WaitForSeconds(2f);
    }

    void detectObjectNearBy(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, this.radius);
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
        transform.LookAt(target);
    }
}
