
[System.Serializable]
public class Player_Death : Achievement
{
    public override void Subscribe()
    {
        TankServices.Instance.playerDeathNotification += CheckAchievement;
    }

    public override void CheckAchievement()
    {
        MarkAcheivementCompleted(this);
        Unsubscribe();
    }

    public override string getMessage(){
        return "Oops PLayer Killed by Eenemy..!!";
    }

    public override void Unsubscribe()
    {
        TankServices.Instance.playerDeathNotification -= CheckAchievement;
    }
}
