using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : SingletonBehaviour<PlayerController>
{
    public float movementSpeed;
    void Start()
    {
        
    }

    private void FixedUpdate() {
        Debug.Log("Horizontal : "+CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("Vertical : "+CrossPlatformInputManager.GetAxis("Vertical"));
        playerMovement();
    }

    void playerMovement(){
        Vector3 currentPosition = transform.position;
        currentPosition.x += CrossPlatformInputManager.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        currentPosition.z += CrossPlatformInputManager.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
