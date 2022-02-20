using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBulletMaster", menuName = "ScriptableObjects/BulletMaster", order = 0)]
public class BulletScriptableObjectMaster : ScriptableObject {
    public BulletView bulletView;
    public BulletScriptableObject[] bulletScriptableObjects;
}