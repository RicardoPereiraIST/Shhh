using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DistractionScript : Entity
{
    // Use this for initialization
    void Start()
    {
        movSpeed = 10f;
        runSpeed = 10f;
        showLight = true;
        isMoving = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
