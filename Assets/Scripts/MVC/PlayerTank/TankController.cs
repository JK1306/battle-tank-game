using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class TankController
{
    public TankModel tankModel;
    public TankView tankView;
    public TankController(TankView tankView, TankModel tankModel){
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        this.tankView.setTankController(this);
    }

    public void tankMovement(){
        Vector3 currentPosition = this.tankView.transform.position;
        currentPosition.x += CrossPlatformInputManager.GetAxis("Horizontal") * this.tankModel.movementSpeed * Time.deltaTime;
        currentPosition.z += CrossPlatformInputManager.GetAxis("Vertical") * this.tankModel.movementSpeed * Time.deltaTime;
        this.tankView.transform.position = currentPosition;
        playerRotation();
    }

    void playerRotation(){
    if(CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0){
        Vector3 currentPosition = this.tankView.transform.position;
        Vector3 tankRotation = new Vector3(
            CrossPlatformInputManager.GetAxis("Horizontal"),
            0f,
            CrossPlatformInputManager.GetAxis("Vertical")
        );
        this.tankView.transform.forward = tankRotation;
        // transform.Rotate(0f, CrossPlatformInputManager.GetAxis("Horizontal"), 0f, Space.Self);
        }
    }
}
