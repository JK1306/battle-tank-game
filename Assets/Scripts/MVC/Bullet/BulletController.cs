﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    ParticleSystem explosion;
    public BulletController(BulletView bulletView, BulletScriptableObject bulletScriptableObject, Transform instantiatePosition, BulletParent bulletParent){
        this.bulletModel = new BulletModel(bulletScriptableObject, bulletParent);
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, instantiatePosition.position, instantiatePosition.rotation);
        this.bulletView.setupController(this);
        this.bulletView.applyMaterial(bulletModel.materialToApply);
    }

    public void triggerBullet(){
        Vector3 forceApplyDirection = Vector3.forward * bulletModel.thrustApplied;
        this.bulletView.GetComponent<Rigidbody>().AddRelativeForce(forceApplyDirection, ForceMode.Force);
    }

    public void manageCollision(Collider collider){
        if( collider.gameObject.GetComponent<TankView>() != null && bulletModel.bulletParent != BulletParent.Player){

            TankServices.Instance.takeDamage(bulletModel.damagePower);
            playBulletShellExplosion(bulletView.transform.position);

        }else if( collider.gameObject.GetComponent<EnemyView>() != null && bulletModel.bulletParent != BulletParent.Enemy ){

            EnemyService.Instance.takeDamage(bulletModel.damagePower);
            playBulletShellExplosion(bulletView.transform.position);

        }else if( collider.gameObject.GetComponent<EnemyView>() == null && collider.gameObject.GetComponent<TankView>() == null){

            playBulletShellExplosion(bulletView.transform.position);

        }
    }

    public async void playBulletShellExplosion(Vector3 particalSpawnPosition){
        GameObject.Destroy(this.bulletView.gameObject);
        this.explosion = GameObject.Instantiate(bulletModel.shellExplosionPartical, particalSpawnPosition, Quaternion.identity);
        this.explosion.Play();
        await waitForSec(0.3f);
        destroyShell();
    }

    public void destroyShell(){
        GameObject.Destroy(this.explosion.gameObject);
    }

    async Task waitForSec(float sec){
        await Task.Delay(TimeSpan.FromSeconds(sec));
    }
}
