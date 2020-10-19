using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
	public GameObject candyCorn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    	if (other.gameObject.CompareTag("Player")){
    		
    		for (int i = 0; i < 20; i ++){
    			Vector3 pos = new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + 2, transform.position.z + Random.Range(-1f, 1f));
				GameObject newCandyCorn = Instantiate(candyCorn, pos, transform.rotation);

            	Destroy(newCandyCorn, 5f);
    		}
    		
   		}
   	}
}
