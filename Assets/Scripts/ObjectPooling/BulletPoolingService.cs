using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolingService : PoolingService<BulletController>
{
    private BulletView bulletView;
    private Transform firePosition;
    private BulletParent bulletParent;
    private BulletScriptableObject bulletScriptableObject;

    public BulletController GetBulletController(BulletView bullet, BulletScriptableObject bulletScriptableObject, Transform firePosition, BulletParent bulletParent){
        this.bulletView = bullet;
        this.bulletScriptableObject = bulletScriptableObject;
        this.firePosition = firePosition;
        this.bulletParent = bulletParent;
        BulletController bulletController = GetObject();
        bulletController.enableObject();
        return bulletController;
    }

    protected override BulletController CreateItem(){
        BulletController bulletController = new BulletController(this.bulletView, this.bulletScriptableObject, this.firePosition, this.bulletParent);
        return bulletController;
    }

    public override void ReturnObject(BulletController returnedObject)
    {
        // Debug.Log("Came to Child Object");
        returnedObject.disableObject();
        base.ReturnObject(returnedObject);
    }
}
