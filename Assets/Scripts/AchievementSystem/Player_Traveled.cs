using UnityEngine;

[System.Serializable]
public class Player_Traveled : Achievement
{
    [SerializeField]
    private float distanceCover;
    public override void Subscribe()
    {
        TankServices.Instance.playerTravelNotification += checkDistanceCovered;
    }

    void checkDistanceCovered(float distanceCovered){
        // Debug.Log("Distance Covered" + distanceCovered);
        if(distanceCovered >= distanceCover){
            CheckAchievement();
        }
    }

    public override void CheckAchievement()
    {
        MarkAcheivementCompleted(this);
        Unsubscribe();
    }

    public override string getMessage(){
        return "Hurray "+distanceCover+"m distance is covered...!!";
    }

    public override void Unsubscribe()
    {
        TankServices.Instance.playerTravelNotification -= checkDistanceCovered;
    }
}
