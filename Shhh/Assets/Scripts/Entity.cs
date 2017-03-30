using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected bool isMoving = false;
    protected bool running = false;
    protected float movSpeed = 2.0f;
    protected float runSpeed = 5.0f;
    protected float stillSpeed = 1.0f;
    public Light spotlight;

    protected virtual void UpdateIntensity()
    {
        if(isMoving || running)
            spotlight.GetComponent<Light>().intensity = running ? runSpeed : movSpeed;
        else
            spotlight.GetComponent<Light>().intensity = stillSpeed;
    }

    // Update is called once per frame
    protected void Update () {
        spotlight.GetComponent<PlayerLight>().UpdateSpotAngle(isMoving, running);
        UpdateIntensity();
    }
}
