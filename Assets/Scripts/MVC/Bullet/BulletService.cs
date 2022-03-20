using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : SingletonBehaviour<BulletService>
{
    public BulletScriptableObjectMaster bulletScriptableObjectMaster;
    BulletController bulletController;
    BulletPoolingService bulletPoolingService;
    private void Start() {
        bulletPoolingService = GetComponent<BulletPoolingService>();
    }
    public void fireBullet(BulletType bulletType, Transform firePosition, BulletParent bulletParent){
        int i=0;
        for(; i<bulletScriptableObjectMaster.bulletScriptableObjects.Length; i++){
            if(bulletScriptableObjectMaster.bulletScriptableObjects[i].bulletType == bulletType){
                break;
            }
        }
        bulletController = bulletPoolingService.GetBulletController(bulletScriptableObjectMaster.bulletView, bulletScriptableObjectMaster.bulletScriptableObjects[i], firePosition, bulletParent);
        // bulletController = new BulletController(bulletScriptableObjectMaster.bulletView, bulletScriptableObjectMaster.bulletScriptableObjects[i], firePosition, bulletParent);
        bulletController.triggerBullet();
    }

    public void ReturnBullet(BulletController bulletController){
        bulletPoolingService.ReturnObject(bulletController);
    }
}
