using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public CharacterController cc;
    float movementSpeed = 1.3f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        // applies gravity
        cc.Move(new Vector3(0, -9.81f, 0));
        // rotates player with camera (which is controlled by mouse)
        transform.rotation = camera.transform.rotation;
        // gets forward and backward input
        //float vAxis = Input.GetAxis("Vertical");

        //cc.Move(vAxis * transform.forward * movementSpeed * Time.deltaTime);
        // Movement
        Vector3 amountToMove = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            amountToMove = transform.forward * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.S))
        {
            amountToMove = transform.forward * -1 * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.A))
        {
            amountToMove = transform.right * -1 * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.D))
        {
            amountToMove = transform.right * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        cc.Move(amountToMove);


    }
}
