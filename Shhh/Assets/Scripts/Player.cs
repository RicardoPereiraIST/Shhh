using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : Entity {

    public float movSpeed = 2.0f;
    public float runSpeed = 5.0f;

    PlayerController controller;

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

    protected override void UpdateIntensity(Vector3 mov)
    {
        if (mov != Vector3.zero)
            spotlight.GetComponent<Light>().intensity = running ? mov.magnitude * runSpeed : mov.magnitude * movSpeed;
        else
            spotlight.GetComponent<Light>().intensity = 1.0f;
    }

    new void Update () {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = (!mov.Equals(Vector3.zero));
        Vector3 moveVelocity = mov.normalized;

        checkRunning();

        moveVelocity *= running ? runSpeed : movSpeed;

        controller.Move(moveVelocity);

        UpdateIntensity(mov);
        base.Update();
    }
}
