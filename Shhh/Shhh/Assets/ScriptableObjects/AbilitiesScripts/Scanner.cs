using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Scanner")]
public class Scanner : Ability
{
    public GameObject[] objectives;

    public override void Initialize(GameObject obj)
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        if (objectives.Length == 0)
            Debug.Log("No game objects are tagged with \"Objective\"");
        objectivesVisible(false);
        return;
    }

    public override bool TriggerAbility()
    {
        FindObjectOfType<ScannerEffect>()._scanning = true;
        FindObjectOfType<ScannerEffect>().ScanDistance = 0;
        FindObjectOfType<Player>().highlight = true;

        objectivesVisible(true);
        return true;
    }

    public void objectivesVisible(bool b)
    {
        foreach (GameObject o in objectives)
        {
            if (b)
                o.SetActive(true);
            else
                o.SetActive(false);
        }  
    }
}
