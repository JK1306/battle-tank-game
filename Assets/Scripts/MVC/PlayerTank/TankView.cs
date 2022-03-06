using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TankView : MonoBehaviour
{
    Vector3 spawnLocation;
    public Transform bulletInstantiatePosition;
    FixedJoystick fixedJoystick;
    TankController tankController;
    private void Start() {
        spawnLocation = transform.position;
    }

    public void setTankController(TankController tankController){
        this.tankController = tankController;
    }

    public void setupJoyStick(Joystick joystick){
        this.fixedJoystick = (FixedJoystick) joystick;
    }

    private void Update() {
        this.tankController.calculateDistance(spawnLocation, transform.position);
        if(this.tankController != null){
            this.tankController.tankMovement(fixedJoystick.Horizontal, fixedJoystick.Vertical);
            this.tankController.playerRotation(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        }

        if(CrossPlatformInputManager.GetButtonDown("Fire")){
            tankController.fireBullet(bulletInstantiatePosition);
        }
    }
}
