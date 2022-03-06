using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public MeshRenderer Chassis,
                        TrackLeft,
                        TrackRight,
                        TankTurrent;

    public void applyMaterial(Material material){
        Chassis.material = material;
        TrackLeft.material = material;
        TrackRight.material = material;
        TankTurrent.material = material;
    }
}
