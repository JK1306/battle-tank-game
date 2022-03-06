using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    BulletModel bulletModel;
    BulletView bulletView;
    List<ParticleSystem> explosion;
    int explosionIndex=0;
    public BulletController(BulletView bulletView, BulletScriptableObject bulletScriptableObject, Transform instantiatePosition, BulletParent bulletParent){
        this.bulletModel = new BulletModel(bulletScriptableObject, bulletParent);
        this.bulletView = GameObject.Instantiate<BulletView>(bulletView, instantiatePosition.position, instantiatePosition.rotation);
        this.bulletView.setupController(this);
        this.bulletView.applyMaterial(bulletModel.materialToApply);
        explosion = new List<ParticleSystem>();
    }

    public void triggerBullet(){
        Vector3 forceApplyDirection = Vector3.forward * bulletModel.thrustApplied;
        this.bulletView.GetComponent<Rigidbody>().AddRelativeForce(forceApplyDirection, ForceMode.Force);
    }

    public void manageCollision(Collider collider){
        if( collider.gameObject.GetComponent<TankView>() != null && bulletModel.bulletParent != BulletParent.Player){

            TankServices.Instance.takeDamage(bulletModel.damagePower);
            bulletView.destroyShell();

        }else if( collider.gameObject.GetComponent<EnemyView>() != null && bulletModel.bulletParent != BulletParent.Enemy ){

            EnemyService.Instance.takeDamage(bulletModel.damagePower);
            bulletView.destroyShell();

        }else if( collider.gameObject.GetComponent<EnemyView>() == null && collider.gameObject.GetComponent<TankView>() == null){

            bulletView.destroyShell();

        }
    }

    public void playBulletShellExplosion(Transform particalSpawnPosition){
        this.explosion.Add(
            GameObject.Instantiate(bulletModel.shellExplosionPartical, particalSpawnPosition.position, Quaternion.identity)
        );
        this.explosion[explosionIndex].Play();
        explosionIndex++;
    }

    public void destroyShell(){
        GameObject.Destroy(this.bulletView.gameObject);
        // Debug.Log("Total Partical : "+explosionIndex);
        for(int i=explosionIndex-1; i>=0; i--){
            // Debug.Log("Index : "+i);
            GameObject.Destroy(this.explosion[i].gameObject);
            this.explosion.RemoveAt(i);
        }
    }
}
