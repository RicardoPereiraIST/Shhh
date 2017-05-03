using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarcolor : MonoBehaviour
{
    public Color edgeColor;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.SetColor("_EdgeColor", edgeColor);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
        other.GetComponent<Renderer>().material.SetColor("_EdgeColor", edgeColor);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag.Equals("enemy"))
        {
            enemy x = other.gameObject.GetComponent<enemy>();
            x.lastX = gameObject.transform.position.x;
            x.lastZ = gameObject.transform.position.z;
        }
        other.GetComponent<Renderer>().material.SetColor("_EdgeColor", edgeColor);
    }
}
