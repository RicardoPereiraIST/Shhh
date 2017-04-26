using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistractionScript : Entity
{
    float distractionTime = 3.5f;

    // Use this for initialization
    void Start()
    {
        movSpeed = 10f;
        runSpeed = 10f;
        showLight = true;
        isMoving = true;
        if (gameObject.activeSelf)
            Destroy(gameObject, distractionTime);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
