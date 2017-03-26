using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : Entity {

    public bool inRange;
    public float lastX;
    public float lastZ;

    // Use this for initialization
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    new void Update()
    {
        if (inRange)
        {
            float step = 0.85f * Time.deltaTime;
            Vector3 position = new Vector3(lastX, 0, lastZ);
            transform.position = Vector3.MoveTowards(transform.position, position, step);
            isMoving = true;
        }
        else
            isMoving = false;

        base.Update();
    }
}
