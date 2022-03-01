using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyState
{
    Transform target;
    float detectRadius;

    public override void Tick(float chaseRadius){
        this.detectRadius = chaseRadius;
        detectObjectNearBy();
        tankMovement();
        tankRotation();
    }

    void tankMovement(){
        if(Vector3.Distance(transform.position, target.position) > 4f){
            transform.position = Vector3.MoveTowards(transform.position, target.position, this.enemyModel.movementSpeed * Time.deltaTime);
        }
    }

    void detectObjectNearBy(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, this.detectRadius);
        if(colliders.Length > 0){
            for(int i=0; i<colliders.Length; i++){
                if(colliders[i].GetComponent<TankView>() != null){
                    target = colliders[i].transform;
                    break;
                }
            }
        }
    }

    void tankRotation(){
        transform.LookAt(target);
    }

}
