using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript1 : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public float rotateDirectionTimer = 4f;
    public float rotateDirectionRate = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        rotateDirectionTimer -= Time.deltaTime;
        if (rotateDirectionTimer < 0){
        	rotateDirectionTimer = rotateDirectionRate;
        	rotationSpeed *= -1;
        }
    }
}
