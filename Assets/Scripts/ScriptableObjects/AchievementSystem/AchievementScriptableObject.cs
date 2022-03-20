using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "DefaultAchivementScriptableObject", menuName = "ScriptableObjects/AchivementSystem", order = 0)]
public class AchievementScriptableObject : ScriptableObject {
    public int testValue;
    public AchievementBlock[] achievements;
    int length;
    bool awakeExe=false;

    private void Awake() {
        Debug.Log("Awake Executed..");
        awakeExe = true;
        if(achievements == null){
            length = 0;
            return;
        }
        length = achievements.Length;
        // displayAchievement();
    }

    private void OnValidate() {
        Debug.Log("OnValidate Executed..");
        // displayAchievement();
        if(length<=0) return;
        if(length < achievements.Length){
            // displayAchievement(achievements[length]);
            achievements[length] = new AchievementBlock();
            length = achievements.Length;
        }
        foreach(var achievement in achievements){
            achievement.UpdateBock();
        }
    }

    void displayAchievement(AchievementBlock achievementL=null){
        if(achievementL != null){
            Debug.Log("Acheivement Name : "+achievementL.achievementType);
            achievementL.displayLastType();
            return;
        }
        foreach(var achievement in achievements){
            Debug.Log("Acheivement Name : "+achievement.achievementType);
            achievement.displayLastType();
        }
    }

    public void Subscribe(){
        foreach(AchievementBlock achievement in achievements){
            if(achievement.achievementType != AchievementType.None)
                achievement.achievement.Subscribe();
        }
    }

    public void Unsubscribe(){
        foreach(AchievementBlock achievement in achievements){
            if(achievement.achievementType != AchievementType.None)
                achievement.achievement.Unsubscribe();
        }
    }
}