using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour {

    public float highlightTime = 5;
    private float lastTime;

	public void HighLight()
    {
        Shader sh = Shader.Find("XRay Shaders/Diffuse-XRay-Replaceable");
        this.GetComponentInChildren<Renderer>().material.shader = sh;
        lastTime = Time.time;
    }

    private void Update()
    {
        if(Time.time > lastTime + highlightTime)
        {
            Shader sh = Shader.Find("Standard");
            this.GetComponentInChildren<Renderer>().material.shader = sh;
            FindObjectOfType<Player>().highlight = true;
        }
    }
}
