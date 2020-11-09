using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HarvesterScript : MonoBehaviour
{
	bool selected;
	bool MoveOrderGiven = false;
	RaycastHit StoredHit;
    // stats
    public float speed = 100f;
    public float rotateSpeed = 90f;
    public int CrystalCapacity;
    public int crystals;
    public int metals;
    Vector3 StartPosition;
    CharacterController cc;
    public GameObject main;
    MainBaseScript mb;

    public int GetCrystals(){
        return crystals;
    }

    public void SetCrystals(int c){
        crystals = c;
    }

    void Start()
    {
        int metals = 0;
        bool selected = false;
        int CrystalCapacity = 3;
        int crystals = 0;
    	cc = GetComponent<CharacterController>();
        StartPosition = this.transform.position;
        this.transform.position = new Vector3(this.transform.position.x - 8, this.transform.position.y, this.transform.position.z);
        main = GameObject.FindWithTag("MainBase");
        mb = main.GetComponent<MainBaseScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (selected == false){

            if (Input.GetMouseButtonDown(0))
            {
                // shoot out a ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // if it hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // if what it hit has the tag that i specified
                    if (hit.collider.gameObject == this.gameObject){
                        // do stuff
                        Debug.Log("Clicked on harvester");
                        selected = true;
                        //BaseCanvas.SetActive(true);
                    }
                }
            } 
        } 
        else {
            // if selected is TRUE
            // if you hit anything but the UI or void
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                	StoredHit = hit;
                    selected = false;
                    //BaseCanvas.SetActive(false);
                    //Debug.Log("Sent out a move order");

                    // MAKE UNIT GO TO POINT ON GROUND
                    MoveOrderGiven = true;
                }
            }
        }
        if (MoveOrderGiven){
    		MoveTowardsTarget(StoredHit.point);
    	}
    }
    private void OnTriggerEnter(Collider other){
    	if (crystals < CrystalCapacity)
    	{
    		if (other.gameObject.CompareTag("Crystal"))
    		{
    			Destroy(other.gameObject);
    			crystals += 1;
                metals += 1;
    		}	
    	
    	} else {
            StoredHit.point = StartPosition;
            MoveOrderGiven = true;
            //selected = false;

        }
        if (other.gameObject.CompareTag("Refinery"))
            {
                Debug.Log("Harvester has " + GetCrystals() + " crystals");
                mb.money += (crystals * 50);
                mb.metals += (metals * 3);
                crystals = 0;
                metals = 0;
                Debug.Log("Harvester now has " + GetCrystals() + " crystals");
                mb.updateStatsUI();
                
                
            }
    	
    }

     void MoveTowardsTarget(Vector3 target) {
      
      //Get the difference.
      if (Vector3.Distance(transform.position, target) > 6f) {
			Vector3 vectorToTarget = target - transform.position;
			vectorToTarget = vectorToTarget.normalized;

			float step = rotateSpeed * Time.deltaTime;

			Vector3 newDirection = Vector3.RotateTowards(transform.forward, vectorToTarget, step, 1);
			transform.rotation = Quaternion.LookRotation(newDirection);
			
			cc.Move(transform.forward * speed * Time.deltaTime);
            cc.Move(new Vector3(0,-9.81f,0));
		} else {
			MoveOrderGiven = false;
		}
 }

}
