using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected bool isMoving = false;
    protected bool running = false;
    protected bool quiet = false;
    protected float movSpeed = 2.0f;
    protected float runSpeed = 5.0f;
    protected float stillSpeed = 1.0f;
    public Light spotlight;
    public bool showLight = false;
    public Transform sphere;

    protected virtual void UpdateIntensity()
    {
        if(isMoving || running)
            spotlight.GetComponent<Light>().intensity = running ? runSpeed : movSpeed;
        else
            spotlight.GetComponent<Light>().intensity = stillSpeed;
    }

    // Update is called once per frame
    protected void Update () {
        if (sphere)
        {
            sphere.GetComponentInChildren<Animator>().SetBool("moving", isMoving);
            sphere.GetComponentInChildren<Animator>().SetBool("running", running);
            sphere.GetComponentInChildren<Animator>().SetBool("quiet", quiet);
        }
        //else
        //{
        //    spotlight.GetComponent<PlayerLight>().GetComponent<Light>().spotAngle = 0;
        //}
    }
}
