using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    protected bool isMoving = false;
    protected bool running = false;
    public Light spotlight;

    protected virtual void UpdateIntensity(Vector3 mov) { }

	// Update is called once per frame
	protected void Update () {
        spotlight.GetComponent<PlayerLight>().UpdateSpotAngle(isMoving, running);
    }
}
