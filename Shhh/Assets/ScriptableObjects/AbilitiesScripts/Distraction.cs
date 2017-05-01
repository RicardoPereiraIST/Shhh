using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Distraction")]
public class Distraction : Ability {

    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override void TriggerAbility()
    {
        if (!FindObjectOfType<Player>().distractionEffect.enabled)
            FindObjectOfType<Player>().distractionEffect.enabled = true;
    }
}