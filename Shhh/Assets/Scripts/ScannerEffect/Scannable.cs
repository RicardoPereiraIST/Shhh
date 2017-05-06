using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour {

    public float highlightTime = 5;
    private float lastTime;

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
    }

    private void Update()
    {
        if(Time.time > lastTime + highlightTime)
        {
            this.GetComponentInChildren<Renderer>().material.shader = originalSh;
            FindObjectOfType<Player>().highlight = true;
        }
    }
}
