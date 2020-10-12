using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMovement : MonoBehaviour
{
    float movementSpeed = 0.001f; // This variable changes
	float baseMovementSpeed = 0.005f;
	float movementSpeedSlowed = 0.0025f;
	float moveTimer = 2.5f;
	float moveRate = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	// Timer 
    	moveTimer -= Time.deltaTime;
    	// Moves platform
    	transform.Translate(Vector3.up * movementSpeed, Space.Self);
    	// Slow down a little bit before changing direction
    	if (moveTimer < 0.5f && moveTimer > 0f){
    		movementSpeed = (movementSpeed > 0) ? movementSpeedSlowed : movementSpeedSlowed * -1;
    	} else {
    		movementSpeed = (movementSpeed > 0) ? baseMovementSpeed : baseMovementSpeed * -1;
    	}
    	// Changes direction after timer
        if (moveTimer <= 0){
        	movementSpeed *= -1;
        	moveTimer = moveRate;
        }
    }
}
