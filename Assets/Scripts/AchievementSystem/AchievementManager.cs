using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementManager : SingletonBehaviour<AchievementManager>
{
    public Text achievementDisplay;
    public AchievementScriptableObject achievementScriptableObject;
    private void Start(){
        achievementScriptableObject.Subscribe();
        Achievement.CompletedAchievement += displayAchievement;
        // Debug.Log("Subscribed to CompletedAchievement");
    }

    private void OnDisable() {
        Achievement.CompletedAchievement -= displayAchievement;
        achievementScriptableObject.Unsubscribe();
    }
    
    void displayAchievement(Achievement achievement){
        StartCoroutine(displayMessage(achievement.getMessage()));
        // Debug.Log("UnSubscribed to CompletedAchievement");
    }

    IEnumerator displayMessage(string msg){
        achievementDisplay.gameObject.SetActive(true);
        achievementDisplay.text = msg;
        yield return new WaitForSeconds(3f);
        achievementDisplay.gameObject.SetActive(false);
    } 
}
