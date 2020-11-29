using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Material color;
    Color originalColor;
    Renderer doorRenderer;
    void Start()
    {
        doorRenderer = this.GetComponent<Renderer>();
        originalColor = color.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        doorRenderer.material.SetColor("_Color", Color.green);
    }

    void OnMouseExit()
    {
        doorRenderer.material.SetColor("_Color", originalColor);
    }

}
