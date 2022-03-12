
[System.Serializable]
public class Enemy_Death : Achievement
{
    public override void Subscribe()
    {
        EnemyService.Instance.enemyDeathNotification += CheckAchievement;
    }

    public override void CheckAchievement()
    {
        MarkAcheivementCompleted(this);
        Unsubscribe();
    }

    public override string getMessage(){
        return "Hurray PLayer Killed Eenemy..!!";
    }

    public override void Unsubscribe()
    {
        EnemyService.Instance.enemyDeathNotification -= CheckAchievement;
    }
}
