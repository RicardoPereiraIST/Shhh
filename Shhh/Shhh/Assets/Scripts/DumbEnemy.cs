
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DumbEnemy : AbstractEnemy {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        movSpeed = 2.4f;
        runSpeed = 5.3f;
    }

    // Update is called once per frame
    new void Update()
    {
        if (!isStunned)
        {
            if (lastPos != this.transform.position)
                lastPos = this.transform.position;

            nav.speed = movSpeed;
            Vector3 position = new Vector3(lastX, 0, lastZ);
            //float distance = Vector3.Distance(transform.position, playerTransform.position);
            GetComponent<Animator>().fireEvents = true;
            GetComponent<Animator>().speed = 0;

            if (lastX != -1 && position != transform.position)
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
            this.GetComponent<Animator>().speed = 0;
            nav.speed = 0;
        }
    }

    protected override void Attacking()
    {
        base.Attacking();
    }

    protected override void Chasing(Vector3 position)
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
        else
        {
            chaseTimer = 0f;
            isMoving = true;
            running = true;

            if (lastPos == this.transform.position)
            {
                lastX = -1;
                lastZ = -1;
            }
            else lastPos = this.transform.position;
        }
    }

    protected override void Patrolling()
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