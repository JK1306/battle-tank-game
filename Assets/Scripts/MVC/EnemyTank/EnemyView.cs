using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    EnemyController enemyController;
    EnemyModel enemyModel;
    float radius=0;
    public MeshRenderer Chassis,
                        TrackLeft,
                        TrackRight,
                        TankTurrent;
    public Transform firingPosition;                        
    public float attackRadius = 3f;
    public float chaseRadius = 6f;

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
        currentState.OnEnterState(this.enemyModel);
        StartCoroutine(startPatroling());
    }

    public void fireShell(){
        this.enemyController.fire(firingPosition);
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
        Collider[] attackColliders = Physics.OverlapSphere(transform.position, attackRadius);
        if(attackColliders.Length > 0){
            int i=0;
            for(; i<attackColliders.Length; i++){
                if(attackColliders[i].GetComponent<TankView>() != null){
                    if(currentState != enemyAttackingState){
                        Debug.Log("Changing State to Attack");
                        changeState(enemyAttackingState);
                        radius = attackRadius;
                    }
                    return;
                }
            }
        }

        Collider[] chasingColliders = Physics.OverlapSphere(transform.position, chaseRadius);
        if(chasingColliders.Length > 0){
            int i=0;
            for(; i<chasingColliders.Length; i++){
                if(chasingColliders[i].GetComponent<TankView>() != null){
                    if(currentState != enemyChasingState){
                        Debug.Log("Changing State to Chasing");
                        changeState(enemyChasingState);
                        radius = chaseRadius;                        
                    }
                    return;
                }
            }
        }
        
        radius = 0;
        if(currentState != enemyIdleState && currentState != enemyPatrollingState){
            Debug.Log("Changing State to Patrolling State");
            changeState(enemyPatrollingState);
        }
    }

    public void changeState(EnemyState nxtState){
        currentState.OnExitState();
        currentState = nxtState;
        currentState.OnEnterState(this.enemyModel);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
