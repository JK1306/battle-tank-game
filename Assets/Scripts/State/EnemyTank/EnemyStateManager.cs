using System.Collections;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyView enemyView;
    EnemyModel enemyModel;
    EnemyState currentState;
    public EnemyStateType currentStateType;
    public float attackRadius = 3f;
    public float chaseRadius = 6f;
    float radius=0;

    private void Start() {
        enemyView = GetComponent<EnemyView>();
        enemyModel = enemyView.enemyModel;

        if(currentStateType == EnemyStateType.None){
            currentStateType = EnemyStateType.Idel;
        }
        changeState(currentStateType);
        currentState.OnEnterState();
        StartCoroutine(startPatroling());
    }

    private void Update() {
        detectObjectNearByObject();
        currentState.Tick(radius);
    }

    public void changeState(EnemyStateType nextState){
        if(currentState != null){
            currentState.OnExitState();
        }
        switch(nextState){
            case EnemyStateType.Idel:
            {
                Debug.Log("Change state to Enemy Idel");
                currentStateType = EnemyStateType.Idel;
                currentState = new EnemyIdleState(enemyModel, enemyView);
                break;
            }

            case EnemyStateType.Patroling:
            {
                Debug.Log("Change state to Enemy Patrol");
                currentStateType = EnemyStateType.Patroling;
                currentState = new EnemyPatrollingState(enemyModel, enemyView);
                break;
            }

            case EnemyStateType.Chasing:
            {
                Debug.Log("Change state to Enemy Chasing");
                currentStateType = EnemyStateType.Chasing;
                currentState = new EnemyChasingState(enemyModel, enemyView);
                break;
            }

            case EnemyStateType.Attacking:
            {
                Debug.Log("Change state to Enemy Attacking");
                currentStateType = EnemyStateType.Attacking;
                currentState = new EnemyAttackingState(enemyModel, enemyView);
                break;
            }
        }
        currentState.OnEnterState();
    }

    IEnumerator startPatroling(){
        yield return new WaitForSeconds(5f);
        changeState(EnemyStateType.Patroling);
    }

    bool collisionDetection(float radius, EnemyStateType enemyState){
        Collider[] attackColliders = Physics.OverlapSphere(transform.position, radius);
        if(attackColliders.Length > 0){
            for(int i=0; i<attackColliders.Length; i++){
                if(attackColliders[i].GetComponent<TankView>() != null){
                    if(currentStateType != enemyState){
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
        if( collisionDetection(attackRadius, EnemyStateType.Attacking)) return;
        if( collisionDetection(chaseRadius, EnemyStateType.Chasing)) return;
        this.radius = 0;
        if(currentStateType != EnemyStateType.Idel && currentStateType != EnemyStateType.Patroling){
            changeState(EnemyStateType.Patroling);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
