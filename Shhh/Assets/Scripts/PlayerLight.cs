using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour {

    public float animationSpeed;

    private int newState = 0;

    public float initSpotAngle;
    public float stopSpotAngle;
    public float walkSpotAngle;
    public float runSpotAngle;

    bool animating = false;

    public void UpdateSpotAngle(bool isMoving, bool running)
    {
        int state = Convert.ToInt32(isMoving) + Convert.ToInt32(running);
        if (!animating)
        {
            StopCoroutine("Animate");
            newState = state;
            StartCoroutine("Animate");
        }
            
        Clamp();
    }

    float stateToAngle(float state)
    {
        if (state == 0)
            return stopSpotAngle;
        else if (state == 1)
            return walkSpotAngle;
        else
            return runSpotAngle;
    }

    void Clamp()
    {
        if (UnityEngine.Random.Range(0, 100) <= 25)
        {
            if (!animating)
            {
                this.GetComponent<Light>().spotAngle += UnityEngine.Random.Range(-2.0f, 2.0f);
                this.GetComponent<Light>().spotAngle = Mathf.Clamp(this.GetComponent<Light>().spotAngle, stateToAngle(newState), stateToAngle(newState) + 5.0f);
            }
            else
            {
                this.GetComponent<Light>().spotAngle += UnityEngine.Random.Range(-2.0f, 2.0f);
            }
        }
    }

    IEnumerator Animate()
    {
        animating = true;
        float percent = 0.0f;
        while (percent <= 1.0f)
        {
            percent += Time.deltaTime * animationSpeed;
            this.GetComponent<Light>().spotAngle = Mathf.Lerp(this.GetComponent<Light>().spotAngle, stateToAngle(newState), percent);
            yield return null;
        }
        this.GetComponent<Light>().spotAngle = initSpotAngle;
        animating = false;
    }
}
