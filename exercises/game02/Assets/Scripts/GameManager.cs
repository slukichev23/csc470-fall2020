using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int confirmedKills = 0;
    

    public GameObject LaserBeamParentPrefab;
    public GameObject alienPrefab;
    
    GameObject laserGun;
    GameObject lunarSurface;

    float makeAlienTimer = 2f;
    float makeAlienRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        laserGun = GameObject.Find("LaserGun");
        lunarSurface = GameObject.Find("Plane");
       
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the timer.
        makeAlienTimer -= Time.deltaTime;
        if (makeAlienTimer < 0)
        {
            
            Vector3 pos = new Vector3(lunarSurface.transform.position.x + Random.Range(-15, 15)
                                , lunarSurface.transform.position.y,
                                lunarSurface.transform.position.z + Random.Range(-15, 15));
            
            GameObject newAlien = Instantiate(alienPrefab, pos, laserGun.transform.rotation);

            Destroy(newAlien, 30f);

            makeAlienTimer = makeAlienRate;

            
        }

        
    }

    public void ShootLaser()
    {
        //UnityEngine.Debug.Log("Pew Pew Pew");
        Vector3 pos = new Vector3(laserGun.transform.position.x
                                    , laserGun.transform.position.y - 0.12f,
                                    laserGun.transform.position.z);
        GameObject laserBullet = Instantiate(LaserBeamParentPrefab, pos, laserGun.transform.rotation);
        Destroy(laserBullet, 3f);
    }
}
