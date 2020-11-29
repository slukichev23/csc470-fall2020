using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Image fadeImage;
    public float fadeRate = 0.3f;

    // Player variables
    public int health = 100;
    public bool hasObtainedKey = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(fade());
    }

    
    void Update()
    {
        
    }

    // coroutine for fade in effect
    IEnumerator fade()
    {
        // You can write linear code inside of this function
        while (fadeImage.color.a >= 0)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - fadeRate * Time.deltaTime);
            yield return null;
        }

    }
}
