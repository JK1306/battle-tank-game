using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel tankModel;
    public TankView tankView;
    public TankController(TankView tankView, TankModel tankModel){
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
    }
}
