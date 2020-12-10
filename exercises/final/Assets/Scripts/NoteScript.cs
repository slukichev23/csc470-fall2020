using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteScript : MonoBehaviour
{
    public GameObject interactImage;
    public Text interactText;
    public GameObject note;
    public Text noteText;
    float fadeRate = 1f;
    // Start is called before the first frame update
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

        if (Vector3.Distance(this.transform.position, GameManager.instance.player.transform.position) < 4.5f)
        {
            interactText.text = "Read";
            interactImage.SetActive(true);
            // player can only attempt to open door if they're within 2 units
            if (Input.GetKey(KeyCode.F))
            {
                interactText.text = "";
                interactImage.SetActive(false);
                //this.gameObject.SetActive(false);
                // Star co routine to fade text on screen
                note.SetActive(true);
                noteText.color = new Color(noteText.color.r, noteText.color.g, noteText.color.b, 100f);
                StartCoroutine(fadeNote());
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

    IEnumerator fadeNote()
    {
        // You can write linear code inside of this function
        while (noteText.color.a >= 0)
        {
            noteText.color = new Color(noteText.color.r, noteText.color.g, noteText.color.b, noteText.color.a - fadeRate * Time.deltaTime);
            yield return null;
        }
        note.SetActive(false);

    }
}
