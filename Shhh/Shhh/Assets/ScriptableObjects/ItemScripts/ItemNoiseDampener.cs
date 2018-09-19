using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[CreateAssetMenu(menuName = "Items/NoiseDampener")]
public class ItemNoiseDampener : ItemAbstract
{
    private int numberOfItems;
    public int effectSeconds;
    private Animator sphere;
    Timer aTimer;

    public override bool CanUseItem()
    {
        return numberOfItems > 0;
    }

    public override void Initialize()
    {
        numberOfItems = 0;
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
        sphere = FindObjectOfType<sonarcolor>().GetComponent<Animator>();
        sphere.SetBool("quiet", true);

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
        sphere.SetBool("quiet", false);
    }
}

