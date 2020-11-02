using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainBaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text BaseSelectedText;
	public bool selected = false;
    public GameObject BaseCanvas;

    void Start()
    {
        BaseCanvas.SetActive(false);
        BaseSelectedText.text = "Base Selected";
    }

    // Update is called once per frame
    void Update()
    {
        // ALL OF THIS IF STATEMENT --> UNDER IF NOT SELECTED SO WE CAN INTERACT WITH UI BUTTONS
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
                    if (hit.collider.gameObject.tag == "MainBase"){
                        // do stuff
                        Debug.Log("Hit main base");
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
                    Debug.Log("Hit Ground");
                }
            }
        }

    if (selected){
        BaseCanvas.SetActive(true);
    } else {
        BaseCanvas.SetActive(false);
    }
    }
}
