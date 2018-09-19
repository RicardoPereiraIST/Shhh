using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Distraction")]
public class Distraction : Ability {
    public override void Initialize(GameObject obj)
    {
        return;
    }

    public override bool TriggerAbility()
    {
        if (FindObjectOfType<Player>().distractionEffect.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && Vector3.Distance(hit.point, FindObjectOfType<Player>().transform.position) < FindObjectOfType<Player>().distractionEffect.transform.localScale.x)
                {
                    FindObjectOfType<Player>().distractionObject.SetActive(true);
                    Instantiate(FindObjectOfType<Player>().distractionObject, hit.point, new Quaternion(0, 0, 0, 0));
                    FindObjectOfType<Player>().distractionObject.SetActive(false);
                    return true;
                }
            }
        }
        return false;
    }
}