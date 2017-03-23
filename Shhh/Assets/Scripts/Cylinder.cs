using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{

    public float animationSpeed;

    private int newState = 0;

    public float initSpotAngle;
    public float stopSpotAngle;
    public float walkSpotAngle;
    public float runSpotAngle;

    bool animating = false;

    public void UpdatePosition(Vector3 pos)
    {
        this.transform.position = new Vector3(pos.x, pos.y - 0.5f, pos.z);
    }

    public void UpdateSpotAngle(bool isMoving, bool running)
    {
        int state = Convert.ToInt32(isMoving) + Convert.ToInt32(running);
        if (!animating)
        {
            StopCoroutine("Animate");
            newState = state;
            StartCoroutine("Animate");
        }

        //Clamp();
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
                float change = UnityEngine.Random.Range(-2.0f, 2.0f);
                float xScale = this.GetComponent<Cylinder>().transform.localScale.x;
                this.GetComponent<Cylinder>().transform.localScale = new Vector3(Mathf.Clamp(xScale + change, stateToAngle(newState), stateToAngle(newState) + 5.0f), this.GetComponent<Cylinder>().transform.localScale.y, Mathf.Clamp(xScale + change, stateToAngle(newState), stateToAngle(newState) + 5.0f));
            }
            else
            {
                float change = UnityEngine.Random.Range(-2.0f, 2.0f);
                float xScale = this.GetComponent<Cylinder>().transform.localScale.x;
                this.GetComponent<Cylinder>().transform.localScale = new Vector3(xScale + change, this.GetComponent<Cylinder>().transform.localScale.y,xScale + change);
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
            float xScale = this.GetComponent<Cylinder>().transform.localScale.x;
            xScale = Mathf.Lerp(xScale, stateToAngle(newState), percent);
            this.GetComponent<Cylinder>().transform.localScale = new Vector3(xScale, this.GetComponent<Cylinder>().transform.localScale.y, xScale);
            yield return null;
        }
        this.GetComponent<Cylinder>().transform.localScale = new Vector3(initSpotAngle, this.GetComponent<Cylinder>().transform.localScale.y, initSpotAngle);
        animating = false;
    }
}
