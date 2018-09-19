using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ChaserEnemy : AbstractEnemy {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        movSpeed = 1.2f;
        runSpeed = 4.0f;
    }

    // Update is called once per frame
    new void Update()
    {
        if (!isStunned)
        {
            Vector3 position = new Vector3(lastX, 0, lastZ);
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            GetComponent<Animator>().fireEvents = true;
            GetComponent<Animator>().speed = 0;
            if (distance < 2)
            {
                Attacking();
                GameManager.getInstance().addDeathByEnemy(this.name);
                GameManager.getInstance().addNewAttempt();
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
        else nav.speed = 0;
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
        }
    }

    protected override void Patrolling()
    {
        nav.speed = movSpeed;
        nav.destination = playerTransform.transform.position;
    }
}
