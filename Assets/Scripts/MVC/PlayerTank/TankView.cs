using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    public void setTankController(TankController tankController){
        this.tankController = tankController;
    }

    private void Update() {
        if(this.tankController != null){
            this.tankController.tankMovement();
        }
    }
}
