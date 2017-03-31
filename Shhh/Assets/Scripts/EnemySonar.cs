using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySonar : MonoBehaviour {

    public Light enemySpotLight;
    public enemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player x = other.gameObject.GetComponent<Player>();
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player x = other.gameObject.GetComponent<Player>();
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player x = other.gameObject.GetComponent<Player>();
            enemy.lastX = other.transform.position.x;
            enemy.lastZ = other.transform.position.z;
        }
    }

    private void Update()
    {
        GetComponent<SphereCollider>().radius = enemySpotLight.spotAngle * 0.08f;
    }
}
