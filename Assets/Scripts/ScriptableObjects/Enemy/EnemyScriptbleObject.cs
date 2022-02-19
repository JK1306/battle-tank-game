using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemy", menuName = "ScriptableObjects/EnemyTank", order = 0)]
public class EnemyScriptbleObject : ScriptableObject {
    public float movementSpeed;
    public float health;
    public Material appliedMaterial;
}