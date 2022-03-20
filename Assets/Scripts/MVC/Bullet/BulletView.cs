using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    public MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void applyMaterial(Material material){
        meshRenderer.material = material;
    }

    private void ResetAppliedForce(){
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void SetPosition(Transform spawnPosition){
        gameObject.transform.position = spawnPosition.position;
        gameObject.transform.rotation = spawnPosition.rotation;
    }   

    public void setupController(BulletController bulletController){
        this.bulletController = bulletController;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("bullet collision collided");
    }

    private void OnTriggerEnter(Collider other) {
        bulletController.manageCollision(other);
    }

    public void disable()
    {
        gameObject.SetActive(false);
    }

    public void enable()
    {
        gameObject.SetActive(true);
        ResetAppliedForce();
    }

}
