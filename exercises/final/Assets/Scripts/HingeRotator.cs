using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HingeRotator : MonoBehaviour
{
    float rotationSpeed = 30f;
    float openTimer = 1.5f;
    float openRate = 1.5f;
    public bool interacted = false;
    public AudioSource openSound;
    public AudioSource closeSound;

    public GameObject player;
    public GameObject interactImage;
    public Text interactText;
    void Start()
    {
        //openSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interacted)
        {
            openTimer -= Time.deltaTime;
            if (openTimer < 0)
            {
                // switches direction after certain time
                rotationSpeed *= -1;
                openTimer = openRate;
                interacted = false;

            }
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        
    }
    private void OnMouseOver()
    {
        // give user UI hint 
       
        if (Vector3.Distance(this.transform.position, player.transform.position) < 4)
        {
            interactText.text = "Open";
            interactImage.SetActive(true);
            // player can only attempt to open door if they're within 2 units
            if (Input.GetKey(KeyCode.F))
            {
                if (!interacted)
                {
                    interacted = true;
                    if (rotationSpeed > 0)
                    {
                        openSound.Play();
                    }
                    else
                    {
                        closeSound.Play();
                    }
                    
                }
                
            }
        }
        else
        {
            interactText.text = "";
            interactImage.SetActive(false);
        }


    }

    private void OnMouseExit()
    {
        interactText.text = "";
        interactImage.SetActive(false);
    }
}
