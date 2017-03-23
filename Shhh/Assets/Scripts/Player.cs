using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour {

    public float movSpeed = 2.0f;
    public float runSpeed = 5.0f;

    PlayerController controller;
    public Light spotlight;

    private bool isMoving = false;
    private bool running = false;

    void Start () {
        controller = GetComponent<PlayerController>();
    }

    private void checkRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    void Update () {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = (!mov.Equals(Vector3.zero));
        Vector3 moveVelocity = mov.normalized;

        checkRunning();

        moveVelocity *= running ? runSpeed : movSpeed;

        controller.Move(moveVelocity);
        
        spotlight.GetComponent<PlayerLight>().UpdatePosition(this.transform.position);
        spotlight.GetComponent<PlayerLight>().UpdateSpotAngle(isMoving, running);
    }
}
