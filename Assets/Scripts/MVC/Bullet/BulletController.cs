using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    public BulletController(BulletView bulletView, BulletScriptableObject bulletScriptableObject, Transform instantiatePosition){
        this.bulletModel = new BulletModel(bulletScriptableObject);
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, instantiatePosition);
        this.bulletView.applyMaterial(bulletModel.materialToApply);
    }

    public void triggerBullet(){
        this.bulletView.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletModel.thrustApplied, ForceMode.Force);
    }
}
