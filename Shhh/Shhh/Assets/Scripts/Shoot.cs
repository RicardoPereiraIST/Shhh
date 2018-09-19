using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject prefab;
    public bool isShooting;
    public float maxDist;
    public GameObject e;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isShooting)
        {
            //Maybe use this to be different each time
            //Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360));
            //print(rot.eulerAngles);

            GameObject binston = Instantiate(prefab, transform.position, Quaternion.Euler(0, 0, 90));
            binston.transform.localScale = Vector3.one;
            binston.GetComponent<BinstonBall>().enemy = e.transform;
            binston.GetComponent<Rigidbody>().velocity = BallisticVel(e.transform);
            isShooting = false;
            Destroy(binston, 20);
        }
    }

    Vector3 BallisticVel(Transform t)
    {
        Vector3 dir = t.position - transform.position;
        float h = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        float a = 45 * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences
                                   // calculate the velocity magnitude
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }
}
