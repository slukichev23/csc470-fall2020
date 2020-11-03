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
    public GameObject BaseCanvas;
    public bool BuildModePowerPlant = false;
    public bool BuildModeRefinery = false;
    public bool BuildModeBarracks = false;
    public bool BuildModeResearch = false;
    public bool BuildModeWarFactory = false;
    public Button PowerPlantBtn;
    public Button RefineryBtn;
    public Button BarracksBtn;
    public Button ResearchBtn;
    public Button WarFactoryBtn;

    // Resource Stats
    public int money = 500;
    public int power = 0;
    public int metals = 50;
    public int techlvl = 0;


    void Start()
    {
        BaseCanvas.SetActive(false);
        updateStatsUI();
        
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
    public void SetBuildModeBarracks(){
        if (money >= 150 && metals >= 10 && power >= 15){
            BuildModeBarracks = true;
            money -= 150;
            metals -= 10;
            power -= 15;
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

    public void updateStatsUI(){
        moneyText.text = money.ToString();
        powerText.text = power.ToString();
        metalsText.text = metals.ToString();
        techlvlText.text = techlvl.ToString();
    }
}
