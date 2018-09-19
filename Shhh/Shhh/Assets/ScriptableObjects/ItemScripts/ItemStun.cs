using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Stun")]
public class ItemStun : ItemAbstract
{
    public float maxDist;
    private int numberOfItems;

    public override bool CanUseItem()
    {
        return numberOfItems > 0;
    }

    public override void Initialize()
    {
        numberOfItems = 0;
        showIcon = CanUseItem();
        showMessage = false;
    }

    public override int getNumberOfItems()
    {
        return numberOfItems;
    }

    public override bool PickUpItem()
    {
        if(maxStack > numberOfItems)
        {
            GameManager.getInstance().addItemsFound(this.iName);
            numberOfItems++;
            showIcon = CanUseItem();
            return true;
        }

        return false;
    }

    public override void UseItem()
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

        if (enemies.Count == 0)
        {
            return;
        }

        GameObject e = enemies.FirstOrDefault(x => x.Value == enemies.Values.Min()).Key;

        while (e.GetComponent<AbstractEnemy>().stunTarget)
        {
            enemies.Remove(e);
            e = enemies.FirstOrDefault(x => x.Value == enemies.Values.Min()).Key;
        }

        if (enemies.Values.Min() <= maxDist)
        {
            e.GetComponent<AbstractEnemy>().stunTarget = true;
            FindObjectOfType<Player>().GetComponent<Shoot>().isShooting = true;
            FindObjectOfType<Player>().GetComponent<Shoot>().e = e;
            numberOfItems--;
        }

        showIcon = CanUseItem();
    }
}

