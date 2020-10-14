﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

	float movementSpeed = 0.5f; // This variable changes
	float baseMovementSpeed = 0.5f;
	float movementSpeedSlowed = 0.25f;
	float moveTimer = 3f;
	float moveRate = 3f;

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
    	transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.Self);
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

    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) {
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			player.PlatformAttachedTo = this;
			Debug.Log("Player has jumped on platform");
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) {
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			player.PlatformAttachedTo = null;
		}
	}
}
