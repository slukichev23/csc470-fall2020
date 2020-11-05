using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefineryScipt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HarvesterPrefab;
    void Start()
    {
        Instantiate(HarvesterPrefab, new Vector3(this.transform.position.x - 15, this.transform.position.y, this.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
