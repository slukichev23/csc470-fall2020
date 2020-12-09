using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGhostScript : MonoBehaviour
{
    // Start is called before the first frame update
    float floatingSpeed = 1.62f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, floatingSpeed * Time.deltaTime);
        transform.LookAt(GameManager.instance.player.transform);
    }
}
