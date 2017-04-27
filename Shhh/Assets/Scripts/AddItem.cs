using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour {

    private Player player;
    public Transform prefab;
    public Transform parentObject;
    public Vector3 rectPos;
    public Vector2 anchorMin;
    public Vector2 anchorMax;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == player.tag)
        {
            GetComponent<Items>().isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == player.tag)
        {
            if (Input.GetKeyDown(GetComponent<Items>().keyToUse))
            {
                if (GetComponent<Items>().pickable)
                {
                    Transform to = Instantiate(prefab);
                    to.SetParent(parentObject, false);
                    to.name = GetComponent<Items>().aName;
                    to.GetComponent<AbilityCoolDown>().ability = GetComponent<Items>().ability;
                    to.GetComponent<AbilityCoolDown>().abilityKey = GetComponent<Items>().keyToUse;
                    to.GetComponent<RectTransform>().position = rectPos;
                    to.GetComponent<RectTransform>().anchorMin = anchorMin;
                    to.GetComponent<RectTransform>().anchorMax = anchorMax;

                    if (player.GetComponent<Player>().items.ContainsKey(GetComponent<Items>().aName))
                    {
                        player.GetComponent<Player>().items[GetComponent<Items>().aName]++;
                    }
                    else
                    {
                        player.GetComponent<Player>().items.Add(GetComponent<Items>().aName, 1);
                    }

                    Destroy(this.gameObject);
                }
                else
                {
                    GetComponent<Items>().doItem();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == player.tag)
        {
            GetComponent<Items>().isTrigger = false;
        }
    }

}
