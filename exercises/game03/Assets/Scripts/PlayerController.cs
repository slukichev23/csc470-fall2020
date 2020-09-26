using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float movementSpeed = 5f;
    float jetPackSpeed = 1f;
    float jetPackFuel = 5f;
    float jetPackAcceleration = 0.1f;
    float jetPackDecceleration = 0.075f;
    float rotateSpeed = 80f;
    GameObject player;
    public ParticleSystem fire;

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
       
        //Debug.Log(rb.velocity);
        
        if (Input.GetKeyDown(KeyCode.Space) && jetPackFuel > 0){
        	fire.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space)){
        	fire.Stop();
        }
        if (Input.GetKey(KeyCode.Space) && jetPackFuel > 0)
        {
        	
            jetPackSpeed += jetPackAcceleration;
            jetPackFuel -= Time.deltaTime;
        	rb.AddForce(new Vector3(0f, 1f * jetPackSpeed, 0f));
        	

        } else if (jetPackFuel >= 0 && ((jetPackSpeed - jetPackDecceleration) > jetPackSpeed)) {
        	jetPackSpeed -= jetPackDecceleration;
        }
        if (jetPackFuel < 0){
        	fire.Stop();
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
