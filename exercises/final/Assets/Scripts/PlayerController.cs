using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public CharacterController cc;
    public AudioSource NoBattery;
    float movementSpeed = 1.3f;
    public bool oneTimeRun = true;
    public GameObject BloodVision;
    public Image Blood;
    float fadeRate = 0.2f;
    public AudioSource music;
    public AudioSource scared;


    void Start()
    {
        music.Play();
    }

    
    void Update()
    {
        if (GameManager.instance.health <= 0)
        {
            SceneManager.LoadScene("LossScene");

        }
        if (GameManager.instance.batteryLeft <= 0)
        {
            music.Stop();
            if (oneTimeRun)
            {
                StartCoroutine(RunOutSound());
            }
            oneTimeRun = false;
        }
        // applies gravity
        cc.Move(new Vector3(0, -9.81f, 0));

        // Movement
        Vector3 amountToMove = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            amountToMove = transform.forward * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.S))
        {
            amountToMove = transform.forward * -1 * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.A))
        {
            amountToMove = transform.right * -1 * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        if (Input.GetKey(KeyCode.D))
        {
            amountToMove = transform.right * Time.deltaTime * movementSpeed;
            cc.Move(amountToMove);
        }
        cc.Move(amountToMove);

        
        FootSteps();


    }
    // footstep sound effects 
    void FootSteps()
    {
        
        if (cc.velocity.magnitude > 0.2f && GetComponent<AudioSource>().isPlaying == false)
        {
            //Debug.Log("Footsteps playing");
            AudioSource sound = this.GetComponent<AudioSource>();
            sound.pitch = Random.Range(0.87f, 1.07f);
            sound.Play();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            GameManager.instance.health = 0;
        }
        if (other.gameObject.CompareTag("Skeleton"))
        {
            Destroy(other.gameObject);
            GameManager.instance.health -= 50;
            BloodVision.SetActive(true);
            StartCoroutine(fade());
            scared.Play();
        }
    }
    IEnumerator RunOutSound()
    {
        NoBattery.Play();
        while (NoBattery.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("LossScene");
    }

    IEnumerator fade()
    {
        // You can write linear code inside of this function
        while (Blood.color.a >= 0)
        {
            Blood.color = new Color(Blood.color.r, Blood.color.g, Blood.color.b, Blood.color.a - fadeRate * Time.deltaTime);
            yield return null;
        }

    }
}
