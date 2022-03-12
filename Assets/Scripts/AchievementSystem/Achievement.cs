using System;

[Serializable]
public abstract class Achievement
{
    public static event Action<Achievement> CompletedAchievement;
    public abstract void Subscribe();
    public abstract void CheckAchievement();
    public abstract void Unsubscribe();
    public abstract string getMessage();
    public void MarkAcheivementCompleted(Achievement completedAchievement){
        CompletedAchievement?.Invoke(completedAchievement);
    }
}
