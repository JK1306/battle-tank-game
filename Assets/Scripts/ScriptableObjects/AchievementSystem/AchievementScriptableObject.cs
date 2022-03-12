using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAchivementScriptableObject", menuName = "ScriptableObjects/AchivementSystem", order = 0)]
public class AchievementScriptableObject : ScriptableObject {
    public AchievementBlock[] achievements;
    int length;

    private void Awake() {
        length = achievements.Length;
    }

    private void OnValidate() {
        if(length != achievements.Length){
            for(int i=0; i<achievements.Length; i++){
                switch(achievements[i].achievementType){
                    case AchievementType.None:
                        achievements[i].achievement = null;
                        break;
                    case AchievementType.Covered_N_Distance:
                        achievements[i].achievement = new Player_Traveled();
                        break;
                    case AchievementType.Enemy_Death:
                        achievements[i].achievement = new Enemy_Death();
                        break;
                    case AchievementType.Player_Death:
                        achievements[i].achievement = new Player_Death();
                        break;
                    case AchievementType.Fire_N_Bullets:
                        achievements[i].achievement = new Fire_N_Bullets();
                        break;
                }
                length = achievements.Length;
            }
        }
    }

    public void Subscribe(){
        foreach(AchievementBlock achievement in achievements){
            achievement.achievement.Subscribe();
        }
    }

    public void Unsubscribe(){
        foreach(AchievementBlock achievement in achievements){
            achievement.achievement.Unsubscribe();
        }
    }
}