using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : Entity {

    //PlayerController controller;
    public Camera xrayCam;
    public MeshRenderer distractionEffect;
    public GameObject distractionObject;
    public bool highlight = false;
    [HideInInspector] public Dictionary<string, int> items = new Dictionary<string, int>();

    private int curMode = 0, lastMode = 0;

    void Start () {
        //controller = GetComponent<PlayerController>();
        movSpeed = 2f;
        runSpeed = 5f;
        showLight = true;
    }

    private void checkRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            running = true;
        }
        else if(isMoving)
        {
            running = false;
        }
        else
        {
            running = false;
        }
    }

    new void Update () {
        Vector3 mov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        isMoving = (!mov.Equals(Vector3.zero));

        checkRunning();

        base.Update();

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            distractionEffect.enabled = !distractionEffect.enabled;
        }

        if (highlight)
        {
            xrayCam.gameObject.SetActive(true);
        }
        else
        {
            xrayCam.gameObject.SetActive(false);
        }

        if (running)
        {
            curMode = 2;
            if (lastMode != curMode)
                GameManager.getInstance().addMovementTriggered("Running");
            lastMode = 2;
        }
        else if (isMoving)
        {
            curMode = 1;
            if (lastMode != curMode)
                GameManager.getInstance().addMovementTriggered("Sneaking");
            lastMode = 1;
        }
        else
        {
            curMode = 0;
            if (lastMode != curMode)
                GameManager.getInstance().addMovementTriggered("Quiet");
            lastMode = 0;
        }
    }

    void OnApplicationQuit()
    {
        GameManager.getInstance().addNewLevel();
        GameManager.getInstance().writeToFile();
    }
}
