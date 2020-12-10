using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScare : MonoBehaviour
{
    // Start is called before the first frame update
    public bool LookedAt = false;
    public float speed = 20f;
    public AudioSource scare;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LookedAt)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, speed * Time.deltaTime);
            //transform.LookAt(GameManager.instance.player.transform);
            
        }
    }
    private void OnMouseEnter()
    {
        LookedAt = true;
        scare.Play();
    }
}
