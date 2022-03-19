using UnityEngine;
[System.Serializable]
public class AchievementBlock
{
    public AchievementType achievementType;
    [SerializeField] private AchievementType lastType;
    [SerializeReference] public Achievement achievement;

    public AchievementBlock(){
        achievementType = AchievementType.None;
        lastType = achievementType;
    }

    public void displayLastType(){
        Debug.Log("Last type : "+lastType);
    }

    public void UpdateBock()
    {
        if(achievementType!=lastType){
            Debug.Log("Last Achievement : "+lastType);
            Debug.Log("Current Achievement : "+achievementType);
            Debug.Log("Achievment Object is Updated");
            switch(achievementType){
                case AchievementType.None:
                    achievement = null;
                    break;
                case AchievementType.Fire_N_Bullets:
                    achievement = new Fire_N_Bullets();
                    break;
                case AchievementType.Covered_N_Distance:
                    achievement = new Player_Traveled();
                    break;
                case AchievementType.Player_Death:
                    achievement = new Player_Death();
                    break;
                case AchievementType.Enemy_Death:
                    achievement = new Enemy_Death();
                    break;
            }
        lastType = achievementType;
        }
    }
}
