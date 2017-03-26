using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.inRange = true;
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.inRange = true;
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.inRange = false;
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
    }
}
