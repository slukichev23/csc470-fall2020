using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainBaseScript : MonoBehaviour
{
    
    public Text BaseSelectedText;
    public Text moneyText;
    public Text powerText;
    public Text metalsText;
    public Text techlvlText;
	public bool selected = false;
	public bool WfcSelected = false;
    public GameObject BaseCanvas;
    public bool BuildModePowerPlant = false;
    public bool BuildModeRefinery = false;
    public bool BuildModeBarracks = false;
    public bool BuildModeResearch = false;
    public bool BuildModeWarFactory = false;
    public Button PowerPlantBtn;
    public Button RefineryBtn;
    public Button ResearchBtn;
    public Button WarFactoryBtn;
    public Button WatchTowerBtn;
    public Button TankBusterBtn;
    public Button MachineGunBtn;
    public Button LaserTurretBtn;
    public GameObject HarvesterPanel;
    public GameObject wfc;
    public Image CrystalMeter;
    public bool BuildModeWatchTower = false;
    public bool BuildModeTankBuster = false;
    public bool BuildModeMachineGun = false;
    public bool BuildModeLaserTurret = false;

    // Resource Stats
    public int money = 500;
    public int power = 0;
    public int metals = 50;
    public int techlvl = 0;


    void Start()
    {
        BaseCanvas.SetActive(false);
        updateStatsUI();
        
        HarvesterPanel.SetActive(false);
        wfc.SetActive(false);
        
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
        if (WfcSelected == false){
            if (Input.GetMouseButtonDown(0))
            {
                // shoot out a ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                // if it hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // if what it hit has the tag that i specified
                    if (hit.collider.gameObject.tag == "WarFactory"){
                        // do stuff
                        Debug.Log("Hit WarFactory");
                        WfcSelected = true;
                        
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
                    WfcSelected = false;
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
        if (WfcSelected){
            wfc.SetActive(true);
        } else {
            wfc.SetActive(false);
        }
    }

    public void SetBuildModePowerPlant(){
        /* Will only build if it meets the requirements
        Money: 100
        Power: N/A
        Metals: 10
        Tech level: N/A
        */
        if (money >= 100 && metals >= 10){
            //PowerPlantBtn.image.color = Color.green;
            BuildModePowerPlant = true;
            money -= 100;
            metals -= 10;
            power += 25;
            selected = false;
        }
    }
    public void SetBuildModeRefinery(){
        if (money >= 250 && metals >= 15 && power >= 25){
            BuildModeRefinery = true;
            money -= 250;
            metals -= 15;
            power -= 25;
            selected = false;
        }
    }
    public void SetBuildModeResearch(){
        if (money >= 500 && metals >= 50 && power >= 100){
            BuildModeResearch = true;
            money -= 500;
            metals -= 50;
            power -= 100;
            selected = false;
        }
    }
    public void SetBuildModeWarFactory(){
        if (money >= 300 && metals >= 30 && power >= 50){
            BuildModeWarFactory = true;
            money -= 300;
            metals -= 30;
            power -= 50;
            selected = false;
        }
    }
    public void SetBuildModeWatchTower(){
        if (money >= 100 && metals >= 10 && power >= 15){
            BuildModeWatchTower = true;
            money -= 100;
            metals -= 10;
            power -= 15;
            WfcSelected = false;
        }
    }
    public void SetBuildModeTankBuster(){
        if (money >= 200 && metals >= 25 && power >= 20){
            BuildModeTankBuster = true;
            money -= 200;
            metals -= 25;
            power -= 20;
            WfcSelected = false;
        }
    }
    public void SetBuildModeMachineGun(){
        if (money >= 360 && metals >= 30 && power >= 35){
            BuildModeMachineGun = true;
            money -= 360;
            metals -= 30;
            power -= 35;
            WfcSelected = false;
        }
    }
    public void SetBuildLaserTurret(){
        if (money >= 600 && metals >= 50 && power >= 100){
            BuildModeLaserTurret = true;
            money -= 600;
            metals -= 50;
            power -= 100;
            WfcSelected = false;
        }
    }

    public void updateStatsUI(){
        moneyText.text = money.ToString();
        powerText.text = power.ToString();
        metalsText.text = metals.ToString();
        techlvlText.text = techlvl.ToString();
    }


}
