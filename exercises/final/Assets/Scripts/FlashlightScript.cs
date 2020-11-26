using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour
{
    // Flashlight variables
    public Light flashLight;
    public Light indirectLight;
    public GameObject FlashLightGO;
    public float directIntensity = 0.5f;
    public float indirectIntensity = 0.3f;
    public bool power = true;
    public float batteryMax = 100f;
    public float batteryLeft = 100f;
    // reference to battery meter
    public Image BatteryFG;
    // timer for updating battery meter
    public float MeterTimer = 5f;
    public float MeterRate = 5f;
    bool RanOutOfBattery = false;
    // reference to camera to get rotation
    public Camera cam;
    CameraScript cs;
    public float verticalPosModifier = 0.01f;
    float FLMaxHeight = 7.1f;
    float FLMinHeight = 5.7f;
    void Start()
    {
        cs = cam.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // matches camera rotation
        //Debug.Log(FlashLightGO.transform.position.y);
        FlashLightGO.transform.rotation = cam.transform.rotation;
        // moves flashlight up or down based on camera y rotation
        float newFLPos = cs.mouseY * verticalPosModifier;
        if (FlashLightGO.transform.position.y <= FLMaxHeight && FlashLightGO.transform.position.y >= FLMinHeight)
        {
            FlashLightGO.transform.position += new Vector3(0, newFLPos, 0);
        }
        else
        {
            // correcting height
            if (FlashLightGO.transform.position.y > FLMaxHeight)
            {
                FlashLightGO.transform.position = new Vector3(FlashLightGO.transform.position.x, FLMaxHeight, FlashLightGO.transform.position.z);
            }
            if (FlashLightGO.transform.position.y < FLMinHeight)
            {
                FlashLightGO.transform.position = new Vector3(FlashLightGO.transform.position.x, FLMinHeight, FlashLightGO.transform.position.z);
            }
        }
        

        if (batteryLeft > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                power = !power;

            }

            if (power) // turning flashlight on
            {
                flashLight.intensity = directIntensity;
                indirectLight.intensity = indirectIntensity;
                // drains battery
                batteryLeft -= Time.deltaTime;
                // timer to update meter only runs when flashlight is on
                MeterTimer -= Time.deltaTime;
                // updates meter
                if (MeterTimer <= 0)
                {
                    BatteryFG.fillAmount = batteryLeft / batteryMax;
                    MeterTimer = MeterRate;
                }
            }
            else // turning flashlight off
            {
                // turns it back on
                flashLight.intensity = 0;
                indirectLight.intensity = 0;
            }
        }
        else
        {
            // if battery below 0, update ran out of battery variable to true and turn off lights for good
            if (!RanOutOfBattery)
            {
                BatteryFG.fillAmount = 0;
                flashLight.intensity = 0;
                indirectLight.intensity = 0;
                RanOutOfBattery = true;
                Debug.Log("Flashlight has run out of battery");
            }
        }
        



    }
}
