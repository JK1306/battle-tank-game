using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : SingletonBehaviour<BulletService>
{
    public BulletScriptableObjectMaster bulletScriptableObjectMaster;
    BulletController bulletController;
    public void fireBullet(BulletType bulletType, Transform firePosition, BulletParent bulletParent){
        int i=0;
        for(; i<bulletScriptableObjectMaster.bulletScriptableObjects.Length; i++){
            if(bulletScriptableObjectMaster.bulletScriptableObjects[i].bulletType == bulletType){
                break;
            }
        }
        bulletController = new BulletController(bulletScriptableObjectMaster.bulletView, bulletScriptableObjectMaster.bulletScriptableObjects[i], firePosition, bulletParent);
        bulletController.triggerBullet();
    }
}
