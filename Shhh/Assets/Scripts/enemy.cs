using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : Entity {

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseWaitTime = 3.5f;
    public float patrolWaitTime = 0.5f;
    public Transform[] patrolWayPoints;

    public bool inRange;
    public float lastX;
    public float lastZ;

    private NavMeshAgent nav;

    private float chaseTimer;
    private float patrolTimer;
    private int wayPointIndex;

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        isMoving = false;
        inRange = false;
        lastX = -1;
        lastZ = -1;
    }

    // Update is called once per frame
    new void Update()
    {
        Vector3 position = new Vector3(lastX, 0, lastZ);
        if (lastX != -1 && position != transform.position)
        {
            Chasing(position);
        }
        else Patrolling();

        base.Update();
    }

    void Attacking()
    {

    }

    void Chasing(Vector3 position)
    {
        nav.destination = position;
        nav.speed = chaseSpeed;
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
        }
        else chaseTimer = 0f;
        isMoving = true;
    }

    void Patrolling()
    {
        nav.speed = patrolSpeed;
        if (nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;
            isMoving = false;
            if (patrolTimer >= patrolWaitTime)
            {
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else wayPointIndex++;

                patrolTimer = 0f;
            }
        }
        else
        {
            patrolTimer = 0f;
            isMoving = true;
        }

        nav.destination = patrolWayPoints[wayPointIndex].position;
    }
}
