using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TankView : MonoBehaviour
{
    public Transform bulletInstantiatePosition;
    FixedJoystick fixedJoystick;
    TankController tankController;
    public void setTankController(TankController tankController){
        this.tankController = tankController;
    }

    public void setupJoyStick(Joystick joystick){
        this.fixedJoystick = (FixedJoystick) joystick;
    }

    private void Update() {
        if(this.tankController != null){
            this.tankController.tankMovement(fixedJoystick.Horizontal, fixedJoystick.Vertical);
            this.tankController.playerRotation(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        }

        if(CrossPlatformInputManager.GetButton("Fire")){
            tankController.fireBullet(bulletInstantiatePosition);
        }

        Debug.Log("Horizontal : "+fixedJoystick.Horizontal);
        Debug.Log("Vertical : "+fixedJoystick.Vertical);
    }
}
