using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class LaserBeamMovement : MonoBehaviour
{
    GameObject laserGun;
    Vector3 direction;
    GameObject gReference;

  
    // Start is called before the first frame update
    void Start()
    {
        gReference = GameObject.FindGameObjectWithTag("Ground");
        laserGun = GameObject.Find("LaserGun");
        direction = laserGun.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0f, 0f, 1f * Time.deltaTime);
        Rigidbody rboby = GetComponent<Rigidbody>();
        rboby.velocity = direction * 40f;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("AlienBoi"))
        {
            
            Destroy(other.gameObject);

            GameManager.confirmedKills += 1;
        }
    }
}
