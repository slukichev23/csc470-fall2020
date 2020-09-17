using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movementSpeed = 5f;
    float rotateSpeed = 80f;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        Rigidbody rb = GetComponent<Rigidbody>();
        // Makes Astronaut jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (player.transform.position.y < -0.82)
            {
                rb.AddForce(new Vector3(0f, 1f, 0f));
            }  
        }

        // Rotation
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.World);

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }





    }
}
