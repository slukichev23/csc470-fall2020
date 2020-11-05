using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UnitScript : MonoBehaviour
{
	bool selected = false;
    // stats
    int health = 1;
    int speed = 1;
    int range = 1;

    void Start()
    {
        
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
                    if (hit.collider.gameObject.tag == "Unit"){
                        // do stuff
                        Debug.Log("Clicked on unit");
                        selected = true;
                        //BaseCanvas.SetActive(true);
                    }
                }
            } 
        } else {
            // if selected is TRUE
            // if you hit anything but the UI or void
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    selected = false;
                    //BaseCanvas.SetActive(false);
                    Debug.Log("Sent out a move order");

                    // MAKE UNIT GO TO POINT ON GROUND
                }
            }
        }
    }
}
