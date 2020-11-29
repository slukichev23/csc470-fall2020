using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource pickup;
    public GameObject player;
    public GameObject interactImage;
    public Text interactText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        // give user UI hint 

        if (Vector3.Distance(this.transform.position, player.transform.position) < 4.5f)
        {
            interactText.text = "Pick Up";
            interactImage.SetActive(true);
            // player can only attempt to open door if they're within 2 units
            if (Input.GetKey(KeyCode.F))
            {
                //pickup.Play();
                AudioSource.PlayClipAtPoint(pickup.clip, transform.position);
                GameManager.instance.hasObtainedKey = true;
                interactText.text = "";
                interactImage.SetActive(false);
                this.gameObject.SetActive(false);
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
