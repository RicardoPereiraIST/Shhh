using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveScript : MonoBehaviour {

    public List<ItemAbstract> items;
    public List<String> objectives;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Objectives";
        GetComponent<Text>().text += string.Format("\nI. {0}", objectives[0]);
        for (int i = 1; i < objectives.Count; i++)
        {
            GetComponent<Text>().text += string.Format("\nII. {0}", objectives[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<Text>().text = "Objectives";
        GetComponent<Text>().text += string.Format("\nI. {0}", objectives[0]);
        for (int i = 1; i < objectives.Count; i++)
        {
            if(!items[i-1].CanUseItem())
                GetComponent<Text>().text += string.Format("\nII. {0}", objectives[i]);
        }

    }
}
