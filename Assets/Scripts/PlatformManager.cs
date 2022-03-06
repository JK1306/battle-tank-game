using System.Collections;
using UnityEngine;

public class PlatformManager : SingletonBehaviour<PlatformManager>
{
    public ParticleSystem explotionParticle;
    ParticleSystem explosion;
    public GameObject[] nonInteractables;

    public void beginEndGame(){
        StartCoroutine(explodeBuilding());
    }

    public IEnumerator explodeBuilding(){
        yield return StartCoroutine(playExplosion());
    }

    public IEnumerator playExplosion(){
        for(int i=0; i<nonInteractables.Length; i++){
            nonInteractables[i].SetActive(false);
            explosion = Instantiate(explotionParticle, nonInteractables[i].transform.position, Quaternion.identity);
            explosion.Play();
            yield return new WaitForSeconds(1f);
            Destroy(nonInteractables[i]);
            Destroy(explosion);
        }
    }
    
}
