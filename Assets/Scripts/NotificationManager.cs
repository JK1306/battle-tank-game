using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private void Start() {
        TankServices.Instance.bulletFireNotification += getNotified;
        TankServices.Instance.playerDeathNotification += getNotifiedOnPlayerDeath;
        TankServices.Instance.playerTravelNotification += getNotifiedOnTravel;
        
        EnemyService.Instance.enemyDeathNotification += getNotifiedOnEnemyDeath;
    }

    public void getNotified(float noOfBullets){
        Debug.Log("Player has shot "+noOfBullets+" of bullets.");
    }

    public void getNotifiedOnEnemyDeath(){
        Debug.Log("Hurray PLayer Killed Eenemy..!!");
    }

    public void getNotifiedOnPlayerDeath(){
        Debug.Log("Oops PLayer Killed by Eenemy..!!");
    }

    public void getNotifiedOnTravel(float distanceTraveled){
        Debug.Log("Congradulations you've traveled "+distanceTraveled+" meters..");
    }

    private void OnDisable() {
        TankServices.Instance.bulletFireNotification -= getNotified;
        TankServices.Instance.playerDeathNotification -= getNotifiedOnPlayerDeath;
        TankServices.Instance.playerTravelNotification -= getNotifiedOnTravel;

        EnemyService.Instance.enemyDeathNotification -= getNotifiedOnEnemyDeath;
    }
}
