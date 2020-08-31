using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    // 2 ways of affection transform: translate and rotate
    // 2 initial params: vector3 (simplest) variable or 3 float values
    void Update()
    {
        // multiply by delta time to make it smooth and framerate independent
        // dynamically changes value of time based upon length of a frame
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
