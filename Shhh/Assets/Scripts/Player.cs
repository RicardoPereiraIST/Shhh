using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public float movSpeed = 2.0f;
    public float runSpeed = 5.0f;

    PlayerController controller;

    private bool running = false;

    void Start () {
        controller = GetComponent<PlayerController>();
    }

    private void checkRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }
    }

    void Update () {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = mov.normalized;

        checkRunning();

        moveVelocity *= running ? runSpeed : movSpeed;

        controller.Move(moveVelocity);
    }
}
