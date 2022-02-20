using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerTank", menuName = "ScriptableObjects/PlayerTank", order = 0)]
public class PlayerTankScriptableObject : ScriptableObject {
    public float health;
    public float movementSpeed;
    public BulletType bulletType;
}
