using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeRotator : MonoBehaviour
{
    float rotationSpeed = 45f;
    float openTimer = 5f;
    float openRate = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openTimer -= Time.deltaTime;
        if (openTimer < 0)
        {
            // switches direction after certain time
            rotationSpeed *= -1;
            openTimer = openRate;

        }
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
