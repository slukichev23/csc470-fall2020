using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSens = 50f;
    public Transform playerLook;
    float rotationX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse x and y component input
        float mouseX = mouseSens * Input.GetAxis("Mouse X");
        float mouseY = mouseSens * Input.GetAxis("Mouse Y");

        // rotating camera but not body
        rotationX -= mouseY; // += rotates in the opposite direction that i want
        // clamping rotation so player's neck doesn't snap
        rotationX = Mathf.Clamp(rotationX, -80f, 60f);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // rotating body but not camera
        playerLook.Rotate(Vector3.up * mouseX);





        

    }
}
