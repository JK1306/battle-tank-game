using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    EnemyController enemyController;
    float radius=0;
    public MeshRenderer Chassis,
                        TrackLeft,
                        TrackRight,
                        TankTurrent;
                        
    public float attackRadius = 3f;
    public float chaseRadius = 6f;

    // Enemy States
    public EnemyIdleState enemyIdleState;
    public EnemyPatrollingState enemyPatrollingState;
    public EnemyChasingState enemyChasingState;
    public EnemyState currentState;

    public void applyMaterial(Material material){
        Chassis.material = material;
        TrackLeft.material = material;
        TrackRight.material = material;
        TankTurrent.material = material;
    }

    public void setupController(EnemyController enemyController){
        this.enemyController = enemyController;
        currentState.OnEnterState(this.enemyController.getModel());
        StartCoroutine(startPatroling());
    }

    IEnumerator startPatroling(){
        yield return new WaitForSeconds(5f);
        changeState(enemyPatrollingState);
    }

    private void Update() {
        detectObjectNearBy();
        currentState.Tick(radius);
    }

    void detectObjectNearBy(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, chaseRadius);
        if(colliders.Length > 0){
            for(int i=0; i<colliders.Length; i++){
                if(colliders[i].GetComponent<TankView>() != null){
                    changeState(enemyChasingState);
                    radius = chaseRadius;
                    break;
                }
            }
        }else{
            radius = 0;
        }
    }

    public void changeState(EnemyState nxtState){
        currentState.OnExitState();
        currentState = nxtState;
        currentState.OnEnterState(enemyController.getModel());
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
