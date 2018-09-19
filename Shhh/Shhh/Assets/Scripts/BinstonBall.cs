using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinstonBall : MonoBehaviour {

    private float speed = 10f;
    public Transform enemy;
    private float lastTime;
    private float timeToDie = 2.0f;
    private bool hasTime = false;
    private float scaleTo = 7.0f;

    private bool hasStartTime = false;
    private float startTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(scale());
        //NEW
        //transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //this.GetComponent<Rigidbody>().useGravity = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform == enemy)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().useGravity = false;
            enemy.gameObject.GetComponent<AbstractEnemy>().isStunned = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.transform == enemy)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, collider.transform.position, speed * Time.deltaTime);
            if (!hasStartTime)
            {
                hasStartTime = true;
                startTime = Time.time;
            }
        }
    }

    private void Update()
    {
        //NEW
        //this.transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);

        if (hasStartTime && Time.time > startTime + 3)
        {
            this.transform.position = enemy.transform.position;
        }

        if (enemy.transform.position == transform.position && !hasTime)
        {
            hasTime = true;
            lastTime = Time.time;
        }

        if (hasTime)
        {
            if (Time.time > lastTime + timeToDie)
            {
                transform.GetComponentInParent<Animator>().SetBool("cage", true);
            }
            if (Time.time > lastTime + timeToDie + 2)
            {
                enemy.gameObject.GetComponent<AbstractEnemy>().isStunned = false;
                enemy.gameObject.GetComponent<AbstractEnemy>().stunTarget = false;
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator scale()
    {
        if (transform.localScale != new Vector3(10, 10, 10))
        {
            float percent = 0.0f;
            while (percent <= 1.0f)
            {
                percent += Time.deltaTime * speed / 10;
                this.transform.localScale = new Vector3(Mathf.Lerp(1.0f, scaleTo, percent), Mathf.Lerp(1.0f, scaleTo, percent), Mathf.Lerp(1.0f, scaleTo, percent));
                yield return null;
            }
        }
    }
}
