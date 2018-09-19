 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemy : Entity {

    public const float KILLING_DISTANCE = 1.5f;

    public float chaseWaitTime = 3.5f;
    public float patrolWaitTime = 0.5f;
    public Transform[] patrolWayPoints;
    public Transform playerTransform;

    public float lastX;
    public float lastZ;

    protected NavMeshAgent nav;

	protected float chaseTimer;
	protected float patrolTimer;
	protected int wayPointIndex;

    public bool isStunned = false;

    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        isMoving = false;
        lastX = -1;
        lastZ = -1;
        movSpeed = 2.4f;
        runSpeed = 5.3f;
        showLight = true;
    }

    // Update is called once per frame
    new void Update()
    {
        if (!isStunned)
        {
            nav.speed = movSpeed;
            Vector3 position = new Vector3(lastX, 0, lastZ);
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            GetComponent<Animator>().fireEvents = true;
            GetComponent<Animator>().speed = 0;

            if (distance < KILLING_DISTANCE)
            {
                Attacking();
            }
            else if (lastX != -1 && position != transform.position)
            {
                GetComponent<Animator>().speed = 2;
                Chasing(position);
            }
            else
            {
                GetComponent<Animator>().speed = 1;
                Patrolling();
            }

            base.Update();
        }
        else
        {
            nav.speed = 0;
        }
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

    void Patrolling()
    {
        nav.speed = movSpeed;
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
