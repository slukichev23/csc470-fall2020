using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryScipt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HarvesterPrefab;
   	public HarvesterScript hs; 
   	public int RefinedCrystal = 0;
   	public int RefinedMetal = 0;
    void Start()
    {
        Instantiate(HarvesterPrefab, new Vector3(this.transform.position.x - 20, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        hs = HarvesterPrefab.GetComponent<HarvesterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
