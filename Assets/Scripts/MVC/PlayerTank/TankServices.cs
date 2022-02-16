using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankServices : MonoBehaviour
{
    public TankView tankView;
    public TankModel tankModel;
    public TankController tankController;
    void Start()
    {
        tankModel = new TankModel();
        tankController = new TankController(tankView, tankModel);
    }

    void Update()
    {
        
    }
}
