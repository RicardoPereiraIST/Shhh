using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item With No Effect")]
public class ItemNoEffect : Ability
{
    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override bool TriggerAbility()
    {
        return false;
    }
}
