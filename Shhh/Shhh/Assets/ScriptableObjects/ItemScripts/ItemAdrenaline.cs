using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[CreateAssetMenu(menuName = "Items/Adrenaline")]
public class ItemAdrenaline : ItemAbstract
{
    private int numberOfItems;
    public int effectSeconds;
    private ThirdPersonCharacter player;
    Timer aTimer;

    public override bool CanUseItem()
    {
        return numberOfItems > 0;
    }

    public override void Initialize()
    {
        numberOfItems = 1;
        showIcon = CanUseItem();
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
        player = FindObjectOfType<Player>().GetComponent<ThirdPersonCharacter>();
        player.m_MoveSpeedMultiplier = 1.8f;

        aTimer = new Timer(effectSeconds*1000);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Enabled = true;

        numberOfItems--;
        showIcon = CanUseItem();
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        //disable the timer
        aTimer.Enabled = false;
        player.m_MoveSpeedMultiplier = 1.0f;
    }
}

