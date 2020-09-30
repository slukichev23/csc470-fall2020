using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float movementSpeed = 5f;
    float rotateSpeed = 80f;

    float jetPackBaseSpeed = 1f;
    float jetPackSpeed = 1f;
    float jetPackFuel = 10f;
    float jetPackAcceleration = 0.15f;
    float jetPackDecceleration = 0.11f;
    public Text fuelText;
    
    GameObject player;

    public ParticleSystem fire;

    Vector3 previousVelocity;
    Vector3 playerVelocity;
    int fallDamageThreshold = -2;
    int fallDamageMultiplier = 3;
    int playerHealth = 100;
    public Text healthText;

    int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        previousVelocity = new Vector3(0,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        // Gets current velocity
        playerVelocity = rb.velocity;

        // Fall damage calculation
        // Added a tolerance of +/- 0.15f, otherwise it would only work half of the time because velocity doesn't always go to exactly 0
        if ((previousVelocity.y < fallDamageThreshold) && ((previousVelocity.y - playerVelocity.y > previousVelocity.y - 0.15f) && (previousVelocity.y - playerVelocity.y < previousVelocity.y + 0.15f) )){
        	Debug.Log("previous y veloctiy: " + previousVelocity.y);
        	Debug.Log("Player has taken " + calculateFallDamage(previousVelocity.y) + " damage!");
        	playerHealth = playerHealth - calculateFallDamage(previousVelocity.y);
        	Debug.Log("New Health: " + playerHealth);
        	healthText.text = playerHealth.ToString();
        }

        // Jetpack particles
        if (Input.GetKeyDown(KeyCode.Space) && jetPackFuel > 0){
        	fire.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space)){
        	fire.Stop();
        }

        // Jetpack speed 
        if (Input.GetKey(KeyCode.Space) && jetPackFuel > 0){
            jetPackSpeed += jetPackAcceleration;
            jetPackFuel -= Time.deltaTime;
            if (jetPackFuel < 0){
            	jetPackFuel = 0;
            }
        	rb.AddForce(new Vector3(0f, 1f * jetPackSpeed, 0f));
        } 
        else if (jetPackFuel >= 0 && ((jetPackSpeed - jetPackDecceleration) > jetPackBaseSpeed)) {
        	jetPackSpeed -= jetPackDecceleration;
        }
        if (jetPackFuel < 0){
        	fire.Stop();
        }

        // Rotation
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.World);

        // Movement
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
        // Updates Fuel
        fuelText.text = (jetPackFuel * 10).ToString();

        // Stores this velocity as next update's previous velocity
        previousVelocity = rb.velocity;
    }

    int calculateFallDamage(float playerV){
    	// Every meter per second beyond fall damage threshold = 1 point of health lost times a multiplier
    	int pVelocity = (int)playerV;
    	// Making value positive to subtract from health. Makes more sense this way
    	int fallDamage = (pVelocity - fallDamageThreshold) * fallDamageMultiplier * -1;
    	return fallDamage;
    }

    private void OnTriggerEnter(Collider other){

    	if (other.gameObject.CompareTag("Fuel")){
     		Debug.Log("Old Fuel: " + jetPackFuel);
     		jetPackFuel = 10f;
     		Debug.Log("Fuel replenished!");
     		Debug.Log("Fuel: " + jetPackFuel);
     		Destroy(other.gameObject);

        } else if (other.gameObject.CompareTag("Health")){
        	Debug.Log("Old Health: " + playerHealth);
     		playerHealth += 25;
     		if (playerHealth > 100){
     			playerHealth = 100;
     		}
     		Debug.Log("+25 health!");
     		Debug.Log("New Health: " + playerHealth);
     		Destroy(other.gameObject);
     		healthText.text = playerHealth.ToString();
        } else if (other.gameObject.CompareTag("Star")){
     		Debug.Log("+1 point!");
     		score += 1;
     		Debug.Log("Total points: " + score);
     		Destroy(other.gameObject);
     		scoreText.text = score.ToString();
        }




     }




    
}
