using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public PlayerController player;
	float platformMovingCameraModifier = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 moveCamera = player.amountToMoveC;
    	moveCamera.y = 0;
        if (player.PlatformAttachedTo != null) {
			moveCamera += player.PlatformAttachedTo.DistanceMoved * platformMovingCameraModifier;
			transform.Translate(moveCamera, Space.World);
		}
        if (Input.GetKey(KeyCode.W)){
        	moveCamera.z = 0;
            transform.Translate(moveCamera, Space.World);
        }
        if (Input.GetKey(KeyCode.S)){
        	moveCamera.z = 0;
            transform.Translate(moveCamera, Space.World);
        }
    }
}
