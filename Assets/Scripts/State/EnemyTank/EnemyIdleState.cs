
// [System.Serializable]
public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyModel enemyModel, EnemyView enemyView) : base(enemyModel, enemyView){
        this.stateType = EnemyStateType.Idel;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
    }
}
