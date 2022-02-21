using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBullet", menuName = "ScriptableObjects/Bullet", order = 0)]
public class BulletScriptableObject : ScriptableObject {
    public Material material;
    public BulletType bulletType;
    public float damage;
    public float thrust;
    public ParticleSystem shellExplosion;
}