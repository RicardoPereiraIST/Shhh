using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Distraction")]
public class DistractionAbility : Ability {

    public int gunDamage = 1;
    public float weaponRange = 50f;
    public float hitforce = 100f;


    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override void TriggerAbility()
    {
        return;
    }
}