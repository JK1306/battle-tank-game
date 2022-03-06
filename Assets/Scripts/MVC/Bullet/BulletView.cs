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

    public void setupController(BulletController bulletController){
        this.bulletController = bulletController;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("bullet collision collided");
    }

    private void OnTriggerEnter(Collider other) {
        bulletController.manageCollision(other);
    }

    public void destroyShell(){
        StartCoroutine(playDestroy());
    }
    IEnumerator playDestroy(){
        this.bulletController.playBulletShellExplosion(transform);
        yield return new WaitForSeconds(0.3f);
        this.bulletController.destroyShell();
    }
}
