using System.Collections;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyView enemyView;
    EnemyModel enemyModel;
    [SerializeReference]
    EnemyState currentState;
    // public EnemyStateType currentStateType;
    public float attackRadius = 3f;
    public float chaseRadius = 6f;
    float radius=0;
    EnemyIdleState enemyIdleState;
    EnemyPatrollingState enemyPatrollingState;
    EnemyChasingState enemyChasingState;
    EnemyAttackingState enemyAttackingState;

    private void Start() {
        enemyView = GetComponent<EnemyView>();
        enemyModel = enemyView.enemyModel;

        enemyIdleState = new EnemyIdleState(enemyModel, enemyView);
        enemyPatrollingState = new EnemyPatrollingState(enemyModel, enemyView);
        enemyChasingState = new EnemyChasingState(enemyModel, enemyView);
        enemyAttackingState = new EnemyAttackingState(enemyModel, enemyView);

        if(currentState == null){
            Debug.Log("Enter Idle state");
            currentState = enemyIdleState;
        }
        currentState.OnEnterState();
        StartCoroutine(startPatroling());
    }

    private void Update() {
        detectObjectNearByObject();
        currentState.Tick(radius);
    }

    public void changeState(EnemyState nextState){
        if(currentState != null){
            currentState.OnExitState();
        }
        switch(nextState.stateType){
            case EnemyStateType.Idel:
            {
                Debug.Log("Change state to Enemy Idel");
                currentState = enemyIdleState;
                break;
            }

            case EnemyStateType.Patroling:
            {
                Debug.Log("Change state to Enemy Patrol");
                currentState = enemyPatrollingState;
                break;
            }

            case EnemyStateType.Chasing:
            {
                Debug.Log("Change state to Enemy Chasing");
                currentState = enemyChasingState;
                break;
            }

            case EnemyStateType.Attacking:
            {
                Debug.Log("Change state to Enemy Attacking");
                currentState = enemyAttackingState;
                break;
            }
        }
        currentState.OnEnterState();
    }

    IEnumerator startPatroling(){
        Debug.Log("Enter Start Patroling");
        yield return new WaitForSeconds(5f);
        Debug.Log("Exit Start Patroling");
        changeState(enemyPatrollingState);
    }

    bool collisionDetection(float radius, EnemyState enemyState){
        Collider[] attackColliders = Physics.OverlapSphere(transform.position, radius);
        if(attackColliders.Length > 0){
            for(int i=0; i<attackColliders.Length; i++){
                if(attackColliders[i].GetComponent<TankView>() != null){
                    if(currentState.stateType != enemyState.stateType){
                        changeState(enemyState);
                        this.radius = radius;
                    }
                    return true;
                }
            }
        }
        return false;
    }

    void detectObjectNearByObject(){
        if( collisionDetection(attackRadius, enemyAttackingState)) return;
        if( collisionDetection(chaseRadius, enemyChasingState)) return;
        this.radius = 0;
        if(currentState.stateType != EnemyStateType.Idel && currentState.stateType != EnemyStateType.Patroling){
            changeState(enemyPatrollingState);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
