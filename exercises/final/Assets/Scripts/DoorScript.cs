using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    AudioSource lockedSound;
    public GameObject player;
    public GameObject interactImage;
    public Text interactText;
    void Start()
    {
        lockedSound = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        // give user UI hint 
        if (Vector3.Distance(this.transform.position, player.transform.position) < 2)
        {
            interactText.text = "Open";
            interactImage.SetActive(true);
            // player can only attempt to open door if they're within 2 units
            if (Input.GetKey(KeyCode.F))
            {
                if (GameManager.instance.hasObtainedKey)
                {
                    // will play a sound, after which it will unlock and take player to end scene
                }
                else
                {
                    // will play locked sound and nothing else
                    if (lockedSound.isPlaying == false)
                    {
                        lockedSound.Play();
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
