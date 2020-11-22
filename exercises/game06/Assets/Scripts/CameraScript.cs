using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH = 1.75f;
    public float speedV = 1.75f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        //yaw = Mathf.Clamp(yaw, -160f, 160f);
        pitch = Mathf.Clamp(pitch, -60f, 90f);
     

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Cursor.lockState = CursorLockMode.Locked;

    }
}
