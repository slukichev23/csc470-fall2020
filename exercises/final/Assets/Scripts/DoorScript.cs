using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    AudioSource lockedSound;
    public AudioSource openSound;
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
            if (GameManager.instance.hasObtainedKey)
            {
                interactText.color = Color.green;
            }
            else
            {
                interactText.color = Color.red;
            }

            interactImage.SetActive(true);
            // player can only attempt to open door if they're within 2 units
            if (Input.GetKey(KeyCode.F))
            {
                if (GameManager.instance.hasObtainedKey)
                {
                    // will play a sound, after which it will unlock and take player to end scene
                    StartCoroutine(OpenDoor());

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
            interactText.color = Color.white;
            interactImage.SetActive(false);
        }
            
        
    }

    private void OnMouseExit()
    {
        interactText.text = "";
        interactText.color = Color.white;
        interactImage.SetActive(false);
    }
    IEnumerator OpenDoor()
    {
        openSound.Play();
        while (openSound.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("WinScene");
    }
}
