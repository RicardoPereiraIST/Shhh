using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Distraction")]
public class DistractionAbility : Ability {

    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override void TriggerAbility()
    {
        FindObjectOfType<Player>().distractionEffect.enabled = !FindObjectOfType<Player>().distractionEffect.enabled;
    }
}