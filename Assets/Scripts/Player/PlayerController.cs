using UnityEngine;

public class PlayerController : SingletonBehaviour<PlayerController>
{
    public float movementSpeed;
    public Quaternion playerQuaternion;
    void Start()
    {
        playerQuaternion = transform.rotation;
    }

    private void FixedUpdate() {
        // Debug.Log("Horizontal : "+CrossPlatformInputManager.GetAxis("Horizontal"));
        // Debug.Log("Vertical : "+CrossPlatformInputManager.GetAxis("Vertical"));
        playerMovement();
        playerRotation();
    }

    void playerMovement(){
        Vector3 currentPosition = transform.position;
        // currentPosition.x += CrossPlatformInputManager.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        // currentPosition.z += CrossPlatformInputManager.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    void playerRotation(){
        // if(CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0){
        //     Vector3 currentPosition = transform.position;
        //     Vector3 tankRotation = new Vector3(
        //         CrossPlatformInputManager.GetAxis("Horizontal"),
        //         0f,
        //         CrossPlatformInputManager.GetAxis("Vertical")
        //     );
        //     transform.forward = tankRotation;
        //     // transform.Rotate(0f, CrossPlatformInputManager.GetAxis("Horizontal"), 0f, Space.Self);
        // }
    }
}
