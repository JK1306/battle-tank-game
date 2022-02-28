using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected EnemyModel enemyModel;
    public virtual void OnEnterState(EnemyModel enemyModel)
    {
        this.enemyModel = enemyModel;
        this.enabled = true;
    }

    public virtual void OnExitState()
    {
        this.enabled = false;
    }

    public virtual void Tick(float target=0f){}

    private void Update() {}
}
