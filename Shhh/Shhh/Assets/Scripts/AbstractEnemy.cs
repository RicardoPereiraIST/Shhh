using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AbstractEnemy : Entity
{

    public const float KILLING_DISTANCE = 1.5f;

    public float chaseWaitTime = 3.5f;
    public float patrolWaitTime = 0.5f;
    public Transform[] patrolWayPoints;
    public Transform playerTransform;

    public float lastX;
    public float lastZ;

    protected Vector3 lastPos;

    protected NavMeshAgent nav;

    protected float chaseTimer;
    protected float patrolTimer;
    protected int wayPointIndex;

    public bool isStunned = false;
    public bool stunTarget = false;

    // Use this for initialization
    protected virtual void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        isMoving = false;
        lastX = -1;
        lastZ = -1;
        showLight = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    protected virtual void Attacking()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected virtual void Chasing(Vector3 position)
    {
        
    }

    protected virtual void Patrolling()
    {
    }
}
