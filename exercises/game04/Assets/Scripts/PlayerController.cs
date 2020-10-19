using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	float moveSpeed = 2.5f;

	public CharacterController cc;

	bool prevIsGrounded = false;

	float yVelocity = 0;
	float jumpForce = 0.05f;
	float gravityModifier = 0.04f;
	static int points = 0;

	public PlatformMovement PlatformAttachedTo;
	public PlatformVerticalMovement PlatformAttachedToV;
	public Vector3 amountToMoveC = new Vector3(0,0,0);
	public SpiderScript spider;
	public GameObject gate;
	public Text pointText;
	
	// Start is called before the first frame update
	void Start()
	{
		cc = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		// updates points 
		pointText.text = points.ToString();
		//--- DEALING WITH GRAVITY ---
		if (!cc.isGrounded) { //If we go in this block of code, cc.isGrounded is false
			//If we're not on the ground, apply "gravity" to yVelocity
			yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

			//If we are moving upward (yVelocity > 0), and the player has released the jump button
			//start falling downward (by setting the yVelocity to 0)
			if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0) {
				yVelocity = 0;
			}
		} else {
			if (!prevIsGrounded) {
				//By being in this if statement, we know we JUST landed.
				//NOTE: We know we just landed because cc.isGrounded is true (meaning
				//		on the last cc.Move() call we collided with something. This condition also
				//		required previousIsGroundedValue to be false which means we were not colliding
				//		with the ground on the previous Update.

				//Set the yVelocity to zero right when we hit the ground so that we don't accumulate 
				//a bunch of yVelocity. The CharacterController will prevent us from moving through
				//the floor, but we are managing the yVelocity ourselves, so we need to make sure
				//that it is zero when we start to fall. This is where we do that.
				yVelocity = 0;
			}

			//JUMP. When the player presses space, set yVelocity to the jump force. This will immediately
			//make the player start moving upwards, and gravity will start slowing the movement upward
			//and eventually make the player hit the ground (thus landing in the 'if' statment above)
			if (Input.GetKeyDown(KeyCode.Space)) {
				yVelocity = jumpForce;
			}
		}

		// Movement
		Vector3 amountToMove = new Vector3(0,0,0);
		if (PlatformAttachedTo != null) {
			amountToMove += PlatformAttachedTo.DistanceMoved;
		}
		if (Input.GetKey(KeyCode.W)){
            amountToMove = transform.forward * Time.deltaTime * moveSpeed;
			cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.S)){
            amountToMove = transform.forward * -1 * Time.deltaTime * moveSpeed;
			cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.A)){
            amountToMove = transform.right * -1 * Time.deltaTime * moveSpeed;
			cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.D)){
            amountToMove = transform.right * Time.deltaTime * moveSpeed;
			cc.Move(amountToMove);
        }
        amountToMove.y = yVelocity;
        cc.Move(amountToMove);
		

		//Set the amount we move in the y direction to be whatever we have gotten from simulating physics
		//amountToMove.y = yVelocity;
		//cc.Move(amountToMove);
		
		//Store our current previousIsGroundedValue (so we can do that check to see if we just
		//landed above as described above)
		//NOTE: After cc.Move() is called, cc.isGrounded is updated to relfect whether that Move()
		//		function call collided with the ground.
		prevIsGrounded = cc.isGrounded;
		amountToMoveC = amountToMove;
	}

	private void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.CompareTag("PileOfCandyCorn")){
    		Destroy(other.gameObject);
    		points += 1;
   		}
   		if (other.gameObject.CompareTag("Key")){
    		Destroy(other.gameObject);
    		gate.SetActive(false);
   		}
   		if (other.gameObject.CompareTag("HugePileOfCandyCorn")){
    		Destroy(other.gameObject);
    		points += 50;
    		spider.spiderMovement = new Vector3(0,0,1) * 0.01f;
   		}
   	}
}
