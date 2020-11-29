using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSens = 50f;
    public Transform playerLook;
    float rotationY = 0f;
    public GameObject FlashlightLight;
    public float mouseX = 0;
    public float mouseY = 0;

    void Start()
    {
        // this looks redundant but this locks the cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse x and y component input
        mouseX = mouseSens * Input.GetAxis("Mouse X");
        mouseY = mouseSens * Input.GetAxis("Mouse Y");

        // rotating camera but not body
        rotationY -= mouseY; // += rotates in the opposite direction that i want
        // clamping rotation so player's neck doesn't snap
        rotationY = Mathf.Clamp(rotationY, -80f, 60f);
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
        FlashlightLight.transform.rotation = this.transform.rotation;
        
        // rotating body but not camera
        playerLook.Rotate(Vector3.up * mouseX);





        

    }
}
