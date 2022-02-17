using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : MonoBehaviour
{
    public TankView tankView;
    public float movementSpeed;
    private TankModel tankModel;
    private TankController tankController;
    void Start()
    {
        tankModel = new TankModel(movementSpeed);
        tankController = new TankController(tankView, tankModel);
    }
}
