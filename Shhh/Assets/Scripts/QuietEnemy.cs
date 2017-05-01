using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class QuietEnemy : enemy {

    private NavMeshAgent nav;

    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex;

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        isMoving = false;
        lastX = -1;
        lastZ = -1;
        movSpeed = 0f;
        runSpeed = 5f;
        showLight = false;
    }

    // Update is called once per frame
    new void Update()
    {
        Vector3 position = new Vector3(lastX, 0, lastZ);
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        GetComponent<Animator>().fireEvents = true;
        GetComponent<Animator>().speed = 0;
        if (distance < 2)
        {
            showLight = true;
            Attacking();
        }
        else if (lastX != -1 && position != transform.position)
        {
            GetComponent<Animator>().speed = 2;
            Chasing(position);
            showLight = true;
        }

        base.Update();
    }

    void Attacking()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Chasing(Vector3 position)
    {
        nav.destination = position;
        nav.speed = runSpeed;
        if (nav.remainingDistance < nav.stoppingDistance)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseWaitTime)
            {
                lastX = -1;
                lastZ = -1;
                chaseTimer = 0f;
            }
            isMoving = false;
            running = false;
        }
        else {
            chaseTimer = 0f;
            isMoving = true;
            running = true;
        }
    }
}
