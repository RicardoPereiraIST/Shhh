using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : Entity {

    PlayerController controller;
    public Camera xrayCam;
    public MeshRenderer distraction;
    private bool highlight = false;

    void Start () {
        controller = GetComponent<PlayerController>();
        movSpeed = 2f;
        runSpeed = 5f;
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

    new void Update () {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = (!mov.Equals(Vector3.zero));
        Vector3 moveVelocity = mov.normalized;

        checkRunning();

        moveVelocity *= running ? runSpeed : movSpeed;

        if(!distraction.enabled)
            controller.Move(moveVelocity);

        base.Update();

        if (Input.GetKeyDown(KeyCode.H))
        {
            highlight = !highlight;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            distraction.enabled = !distraction.enabled;
        }

        if(distraction.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(spotlight, hit.point, new Quaternion(0,0,0,0));
                }
            }
        }

        if (highlight)
        {
            xrayCam.gameObject.SetActive(true);
        }
        else
        {
            xrayCam.gameObject.SetActive(false);
        }
    }
}
