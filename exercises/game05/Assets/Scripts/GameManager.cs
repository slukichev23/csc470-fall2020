using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainBase;
    public GameObject PowerPlantPrefab;
    public GameObject RefineryPrefab;
    public GameObject ResearchPrefab;
    public GameObject WarFactoryPrefab;
    public GameObject WatchTowerPrefab;
    public GameObject TankBusterPrefab;
    public GameObject MachineGunPrefab;
    public GameObject LaserTurretPrefab;
    
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
    		else
    		{
    			mb.PowerPlantBtn.image.color = Color.white;
    		}
    	}
    	if (mb.BuildModeRefinery == false){
    		if (!(mb.money >= 250 && mb.metals >= 15 && mb.power >= 25))
    		{
    			mb.RefineryBtn.image.color = Color.red;
    		}
    		else
    		{
    			mb.RefineryBtn.image.color = Color.white;
    		}
    	}
    	if (mb.BuildModeResearch == false){
    		if (!(mb.money >= 500 && mb.metals >= 50 && mb.power >= 100))
    		{
    			mb.ResearchBtn.image.color = Color.red;
    		}
    		else
    		{
    			mb.ResearchBtn.image.color = Color.white;
    		}
    	}
    	if (mb.BuildModeWarFactory == false){
    		if (!(mb.money >= 300 && mb.metals >= 30 && mb.power >= 50))
    		{
    			mb.WarFactoryBtn.image.color = Color.red;
    		}
    		else
    		{
    			mb.WarFactoryBtn.image.color = Color.white;
    		}
    	}
        if (mb.BuildModeWatchTower == false){
            if (!(mb.money >= 100 && mb.metals >= 10 && mb.power >= 15))
            {
                mb.WatchTowerBtn.image.color = Color.red;
            }
            else
            {
                mb.WatchTowerBtn.image.color = Color.white;
            }
        }
        if (mb.BuildModeTankBuster == false){
            if (!(mb.money >= 200 && mb.metals >= 25 && mb.power >= 20))
            {
                mb.TankBusterBtn.image.color = Color.red;
            }
            else
            {
                mb.TankBusterBtn.image.color = Color.white;
            }
        }
        if (mb.BuildModeMachineGun == false){
            if (!(mb.money >= 360 && mb.metals >= 30 && mb.power >= 35))
            {
                mb.MachineGunBtn.image.color = Color.red;
            }
            else
            {
                mb.MachineGunBtn.image.color = Color.white;
            }
        }
        if (mb.BuildModeLaserTurret == false){
            if (!(mb.money >= 600 && mb.metals >= 50 && mb.power >= 100))
            {
                mb.LaserTurretBtn.image.color = Color.red;
            }
            else
            {
                mb.LaserTurretBtn.image.color = Color.white;
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
                    
                }
            }
        } else if (mb.BuildModeRefinery){
        	if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log("Refinery built");
                    mb.BuildModeRefinery = false;
                    Instantiate(RefineryPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                    
                }
            }
        } else if (mb.BuildModeResearch){
        	if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log("Research Center built");
                    mb.BuildModeResearch = false;
                    Instantiate(ResearchPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();

                    mb.ObjetiveCompleted = true;
                    
                }
            }
        } else if (mb.BuildModeWarFactory){
        	if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    Debug.Log("War Factory built");
                    mb.BuildModeWarFactory = false;
                    Instantiate(WarFactoryPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                    
                }
            }
        } else if (mb.BuildModeWatchTower){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    mb.BuildModeWatchTower = false;
                    Instantiate(WatchTowerPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                }
            }
        } else if (mb.BuildModeTankBuster){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    mb.BuildModeTankBuster = false;
                    Instantiate(TankBusterPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                }
            }
        } else if (mb.BuildModeMachineGun){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    mb.BuildModeMachineGun = false;
                    Instantiate(MachineGunPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                }
            }
        } else if (mb.BuildModeLaserTurret){
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    mb.BuildModeLaserTurret = false;
                    Instantiate(LaserTurretPrefab, hit.point, Quaternion.identity);
                    mb.updateStatsUI();
                }
            }
        }
    }
}
