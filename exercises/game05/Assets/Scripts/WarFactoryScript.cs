using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WarFactoryScript : MonoBehaviour
{
	public GameObject wfc;
    public bool selected = false;
    void Start()
    {
        wfc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
