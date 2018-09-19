using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

    private float rotation = -110;
    private bool closed = true;
    private bool unlocked = false;
    private string howToUse;
    private bool isTrigger;

    public ItemAbstract item;

    private void Start()
    {
        howToUse = "Find " + item.iName + " to unlock";
        isTrigger = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!item.CanUseItem())
        {
            howToUse = "Find " + item.iName + " to unlock";
        }
        isTrigger = true;
    }

    private void OnGUI()
    {
        if (isTrigger)
        {
            GUIContent content = new GUIContent(howToUse);
            GUIStyle style = GUI.skin.box;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;
            Vector2 size = style.CalcSize(content);
            //GUI.Label(new Rect(10, 10, 2.0f * size.x, 2.0f * size.y), content, style);
            GUI.Label(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 100, 2.0f * size.x, 2.0f * size.y), content, style);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (item.CanUseItem())
        {
            howToUse = "Press " + item.itemKey + " to unlock door";
            if (!unlocked && Input.GetKeyDown(item.itemKey))
            {
                unlocked = true;
                closed = false;
                transform.Rotate(0, rotation, 0);
                rotation = -rotation;
                howToUse = "Press " + item.itemKey + " to close";
                item.UseItem();
            }

            else if (unlocked && closed && Input.GetKeyDown(item.itemKey))
            {
                transform.Rotate(0, rotation, 0);
                rotation = -rotation;
                howToUse = "Press " + item.itemKey + " to close";
            }
            else if (unlocked && !closed && Input.GetKeyDown(item.itemKey))
            {
                transform.Rotate(0, rotation, 0);
                rotation = -rotation;
                closed = !closed;
                howToUse = "Press " + item.itemKey + " to open";
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isTrigger = false;
    }
}
