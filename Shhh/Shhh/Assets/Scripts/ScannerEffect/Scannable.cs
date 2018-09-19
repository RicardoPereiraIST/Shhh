using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour {

    public float highlightTime = 5;
    private float lastTime;
    private bool isHighlight = false;

    public Shader originalSh;
    public Shader finalSh;
    public Color color = Color.white;

    private void Start()
    {
        originalSh = this.GetComponentInChildren<Renderer>().material.shader;
    }


    public void HighLight()
    {
        this.GetComponentInChildren<Renderer>().material.shader = finalSh;
        this.GetComponentInChildren<Renderer>().material.color = color;
        lastTime = Time.time;
        isHighlight = true;
    }

    private void Update()
    {
        if(Time.time > lastTime + highlightTime && isHighlight)
        {
            isHighlight = false;
            this.GetComponentInChildren<Renderer>().material.shader = originalSh;
            FindObjectOfType<Player>().highlight = true;
        }
    }
}
