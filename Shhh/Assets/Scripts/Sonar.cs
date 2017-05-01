using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

    public Light playerSpotLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
        
    }

    private void Update()
    {
        GetComponent<SphereCollider>().radius = playerSpotLight.spotAngle * 0.08f;
    }
}
