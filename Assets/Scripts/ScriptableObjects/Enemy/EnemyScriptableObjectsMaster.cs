using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemyScriptableObjectsMaster", menuName = "ScriptableObjects/EnemyTankMaster", order = 0)]
public class EnemyScriptableObjectsMaster : ScriptableObject {
    public EnemyView enemyView;
    public EnemyScriptbleObject[] enemyScriptbleObjects;
}