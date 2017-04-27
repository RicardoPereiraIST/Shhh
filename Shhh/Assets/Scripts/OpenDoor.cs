using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    private Player player;
    private bool isTrigger;
    private string howToUse;
    private float rotation = 90;
    public KeyCode keyToUse;
    private bool open = false;
    private bool close = true;
    private bool unlocked = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        howToUse = "Find key to unlock";
    }

    private void OnGUI()
    {
        if (isTrigger)
        {
            GUIContent content = new GUIContent(howToUse);
            GUIStyle style = GUI.skin.box;
            style.alignment = TextAnchor.MiddleCenter;
            Vector2 size = style.CalcSize(content);
            GUI.Label(new Rect(10, 10, 2.0f * size.x, 2.0f * size.y), howToUse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isTrigger = true;
        if (player.items.ContainsKey("key"))
            howToUse = "Press " + keyToUse + " to unlock";
    }

    private void OnCollisionStay(Collision other)
    {
        if (player.items.ContainsKey("key") && Input.GetKeyDown(keyToUse))
        {
            unlocked = true;
            open = true;
            close = false;
            transform.Rotate(0, rotation, 0);
            rotation = -rotation;
            howToUse = "Press " + keyToUse + " to close";
            player.items.Remove("key");
            GameObject go = GameObject.Find("UI/key");
            Destroy(go);
        }

        else if (unlocked && close && Input.GetKeyDown(keyToUse))
        {
            transform.Rotate(0, rotation, 0);
            rotation = -rotation;
            open = !open;
            close = !close;
            howToUse = "Press " + keyToUse + " to close";
        }
        else if(unlocked && open && Input.GetKeyDown(keyToUse))
        {
            transform.Rotate(0, rotation, 0);
            rotation = -rotation;
            open = !open;
            close = !close;
            howToUse = "Press " + keyToUse + " to open";
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isTrigger = false;
    }
}
