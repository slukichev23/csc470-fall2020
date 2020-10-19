using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderScript : MonoBehaviour
{
    // When big pile of candy corn is picked up, spider will "run" at the player
    // upon collision, player will lose.
	public Vector3 spiderMovement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(spiderMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.CompareTag("Player")){
    		SceneManager.LoadScene("DeathScene");
   		}
   	}
}
