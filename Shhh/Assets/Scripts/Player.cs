using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : Entity {

    PlayerController controller;
    public Camera xrayCam;
    public MeshRenderer distractionEffect;
    public GameObject distractionObject;
    public bool highlight = false;

    void Start () {
        controller = GetComponent<PlayerController>();
        movSpeed = 2f;
        runSpeed = 5f;
        showLight = true;
    }

    private void checkRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            running = false;
        }
        else if(isMoving)
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
        //Vector3 moveVelocity = mov.normalized;

        checkRunning();

        //moveVelocity *= running ? movSpeed : runSpeed;

        //if(!distractionEffect.enabled)
        //    controller.Move(moveVelocity);

        base.Update();

        /*if (Input.GetKeyDown(KeyCode.H))
        {
            highlight = !highlight;
        }*/

        if(Input.GetKeyDown(KeyCode.E))
        {
            distractionEffect.enabled = !distractionEffect.enabled;
        }

        if(distractionEffect.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && Vector3.Distance(hit.point, transform.position) < distractionEffect.transform.localScale.x)
                {
                    distractionObject.SetActive(true);
                    Instantiate(distractionObject, hit.point, new Quaternion(0,0,0,0));
                    distractionObject.SetActive(false);
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
