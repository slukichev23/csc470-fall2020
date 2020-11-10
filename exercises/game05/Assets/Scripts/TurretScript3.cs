using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript3 : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float rotateDirectionTimer = 8f;
    public float rotateDirectionRate = 8f;
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