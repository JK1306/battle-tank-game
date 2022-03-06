using UnityEngine;

public class TankController
{
    public float bulletFireCount { get; private set; }
    public TankModel tankModel;
    public TankView tankView;
    float distance;
    bool distanceNotified;
    public TankController(TankView tankView, Joystick joystick, PlayerTankScriptableObject playerTankScriptableObject){
        this.tankModel = new TankModel(playerTankScriptableObject);
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        this.tankView.setupJoyStick(joystick);
        this.tankView.setTankController(this);
        bulletFireCount = 0;
        distanceNotified = false;
    }

    public void tankMovement(float horizontal, float vertical){
        Vector3 currentPosition = this.tankView.transform.position;
        // if(Input.touchCount > 0){
            currentPosition.x += (horizontal * Time.deltaTime) * this.tankModel.movementSpeed;
            currentPosition.z += (vertical * Time.deltaTime) * this.tankModel.movementSpeed;
        // }
        this.tankView.transform.position = currentPosition;
    }

    public void fireBullet(Transform bulletSpawnPosition)
    {
        bulletFireCount++;
        BulletService.Instance.fireBullet(tankModel.bulletType, bulletSpawnPosition, BulletParent.Player);
        if(bulletFireCount == 10 || bulletFireCount == 25 || bulletFireCount == 50){
            TankServices.Instance.notifyBulletFireAchievement(bulletFireCount);
        }
    }

    public void playerRotation(float horizontal, float vertical){
        if(vertical != 0 || horizontal != 0){
            Vector3 currentPosition = this.tankView.transform.position;
            Vector3 tankRotation = new Vector3(
                    horizontal,
                    0f,
                    vertical
                    // Mathf.Abs(vertical)
                );
            tankRotation = tankRotation.normalized;
            this.tankView.transform.forward = tankRotation;
        }
    }

    public void reduceHealth(float damageTaken){
        if(tankModel.health - damageTaken <= 0){
            GameObject.Destroy(this.tankView.gameObject);
            TankServices.Instance.notifyOnPlayerDeath();
        }else{
            tankModel.health -= damageTaken;
        }
    }

    public void calculateDistance(Vector3 initialPosition, Vector3 currentPosition){
        distance = Vector3.Distance(initialPosition, currentPosition);
        if(distance >= 5f && !distanceNotified){
            TankServices.Instance.notifyOnTraveled5m(distance);
            distanceNotified = true;
        }
    }
}
