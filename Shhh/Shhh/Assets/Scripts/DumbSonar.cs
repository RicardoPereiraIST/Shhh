using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbSonar : MonoBehaviour {

    public AbstractEnemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Distraction"))
        {
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Distraction"))
        {
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Distraction"))
        {
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }
}
