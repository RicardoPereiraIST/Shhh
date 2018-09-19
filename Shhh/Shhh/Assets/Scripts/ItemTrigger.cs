using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrigger : MonoBehaviour {

    private Player player;
    public ItemAbstract item;
    public KeyCode keyToPick;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag)
        {
            item.showMessage = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == player.tag)
        {
            if (Input.GetKeyDown(keyToPick))
            {
                if (item.PickUpItem())
                {
                    item.showMessage = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == player.tag)
        {
            item.showMessage = false;
        }
    }

}
