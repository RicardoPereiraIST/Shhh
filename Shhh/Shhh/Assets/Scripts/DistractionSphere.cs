using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 localScale = gameObject.transform.localScale;
        if (localScale.x >= 10)
            localScale = new Vector3(localScale.x - 0.30f, localScale.y, localScale.z - 0.30f);

        gameObject.transform.localScale = localScale;
    }
}
