using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMovement : MonoBehaviour
{
    // basically prof's code, couldn't get player to ride platform with what i had before
	float freq = 0.8f;
    float amp = 1.4f;

    float theta = 0;

    Vector3 startPosition;
    Vector3 previousPosition;
    public Vector3 DistanceMoved = Vector3.zero;

   
    void Start()
    {
        startPosition = transform.position;
        previousPosition = transform.position;
    }

    
    void Update()
    {
    	theta += Time.deltaTime;
        // mostly because of these 2 lines:
        // I was using a timer to decide when platforms switched direction, not sin
        Vector3 newPos = startPosition + transform.up * Mathf.Sin(theta * freq) * amp;
        transform.position = newPos;
        
     
        DistanceMoved = transform.position - previousPosition;

        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Collision detected");
		if (other.CompareTag("Player")) {
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			player.PlatformAttachedToV = this;
			Debug.Log("Player has jumped on platform");
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) {
			PlayerController player = other.gameObject.GetComponent<PlayerController>();
			player.PlatformAttachedToV = null;
		}
	}
}
