using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Scanner")]
public class Scanner : Ability
{

    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override void TriggerAbility()
    {
        FindObjectOfType<ScannerEffect>()._scanning = true;
        FindObjectOfType<ScannerEffect>().ScanDistance = 0;
        FindObjectOfType<Player>().highlight = true;
    }
}
