using UnityEngine;

[System.Serializable]
public class Fire_N_Bullets : Achievement
{
    [SerializeField]
    private int noOfBullets;
    int bulletCount;
    public override void Subscribe()
    {
        bulletCount = 0;
        TankServices.Instance.bulletFireNotification += CheckAchievement;
    }

    public override void CheckAchievement(){
        bulletCount++;
        if(bulletCount >= noOfBullets){
            this.MarkAcheivementCompleted(this);
            Unsubscribe();
        }
    }

    public override string getMessage(){
        return "Firing "+noOfBullets+" no. of Bullets Achievement is Completed";
    }

    public override void Unsubscribe()
    {
        TankServices.Instance.bulletFireNotification -= CheckAchievement;
    }
}
