using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/BinstonStun")]
public class Stun : Ability
{
    public float maxDist;

    public override void Initialize(GameObject obj)
    {
        FindObjectOfType<Player>().GetComponent<Shoot>().maxDist = maxDist;
        return;
    }

    public override bool TriggerAbility()
    {
        Dictionary<GameObject, float> enemies = new Dictionary<GameObject, float>();
        Transform player = FindObjectOfType<Player>().transform;
        foreach (GameObject en in GameObject.FindGameObjectsWithTag("enemy"))
        {
            if (!en.GetComponent<AbstractEnemy>().isStunned)
            {
                float dist = Vector3.Distance(player.position, en.transform.position);
                enemies.Add(en, dist);
            }
        }

        if(enemies.Count == 0)
        {
            return false;
        }

        GameObject e = enemies.FirstOrDefault(x => x.Value == enemies.Values.Min()).Key;

        while(e.GetComponent<AbstractEnemy>().stunTarget)
        {
            enemies.Remove(e);
            e = enemies.FirstOrDefault(x => x.Value == enemies.Values.Min()).Key;
        }

        if (enemies.Values.Min() <= maxDist)
        {
            e.GetComponent<AbstractEnemy>().stunTarget = true;
            FindObjectOfType<Player>().GetComponent<Shoot>().isShooting = true;
            FindObjectOfType<Player>().GetComponent<Shoot>().e = e;
            return true;
        }
        return false;
    }
}