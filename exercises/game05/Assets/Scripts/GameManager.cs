using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainBase;
    public GameObject PowerPlantPrefab;
    MainBaseScript mb;

    void Start()
    {

        mb = MainBase.GetComponent<MainBaseScript>();
    }

    // Update is called once per frame
    void Update()
    {


    	// Updates color of buildings to tell player if they can build them or not (red for no white for yes)
    	if (mb.BuildModePowerPlant == false){
    		if (!(mb.money >= 100 && mb.metals >= 10))
    		{
    			mb.PowerPlantBtn.image.color = Color.red;
    		}
    	}


        // Handles placing down buildings
        if (mb.BuildModePowerPlant){
        	// When player clicks on ground, that's where prefab will be created
        	if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log("Power Plant built");
                    mb.BuildModePowerPlant = false;
                    Instantiate(PowerPlantPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                    mb.PowerPlantBtn.image.color = Color.white;
                }
            }
        }
    }
}
