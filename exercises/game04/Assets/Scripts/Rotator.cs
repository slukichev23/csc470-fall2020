using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    float rotateSpeed = 95;
    void Start()
    {
        
    }

    void Update()
    {
    	// Rotating player for that spooky effect
        transform.Rotate(0,rotateSpeed * Time.deltaTime, 0);
    }
}
