using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Key")]
public class ItemKey : ItemAbstract
{
    private bool hasKey;

    public override void Initialize()
    {
        hasKey = false;
        showIcon = false;
        showMessage = false;
    }

    public override int getNumberOfItems()
    {
        return -1;
    }

    public override bool PickUpItem()
    {
        if (!hasKey)
        {
            hasKey = true;
            showMessage = false;
            showIcon = true;
            GameManager.getInstance().addItemsFound(this.iName);
            return true;
        }
        else return false;
    }

    public override bool CanUseItem()
    {
        return hasKey;
    }

    public override void UseItem()
    {
        hasKey = false;
        showIcon = false;
        GameManager.getInstance().addItemsUsed(this.name);
    }
}
