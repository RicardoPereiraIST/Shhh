using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public Transform wall;
    private Vector3 pos;
    private Quaternion rot;
    public Vector3 newPos;
    public Vector3 newRot;
    public KeyCode keyToUse;
    private Player player;
    private bool used = false;
    private bool isColliding = false;
    private string howToUse;

    private bool animating = false;
    private float animationSpeed = 10;
    private float startTime;
    private bool pressed = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        pos = wall.position;
        rot = wall.rotation;
        howToUse = "Press " + keyToUse + " to open!";
    }

    private void OnGUI()
    {
        if (isColliding && !animating)
        {
            GUIContent content = new GUIContent(howToUse);
            GUIStyle style = GUI.skin.box;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;
            Vector2 size = style.CalcSize(content);
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 100, 2.0f * size.x, 2.0f * size.y), content, style);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag.Equals(player.tag))
        {
            isColliding = true;
        }
    }

    void OnCollisionStay(Collision c)
    {
        if (c.transform.tag.Equals(player.tag))
        {
            if (Input.GetKeyDown(keyToUse))
            {
                if (!animating)
                {
                    used = !used;
                    pressed = true;
                    startTime = Time.time;
                }
            }
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.transform.tag.Equals(player.tag))
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        if (pressed)
        {
            animating = true;
            if (used)
            {
                float percent = (Time.time - startTime) / animationSpeed;
                wall.transform.position = new Vector3(Mathf.Lerp(wall.position.x, newPos.x, percent), Mathf.Lerp(wall.position.y, newPos.y, percent), Mathf.Lerp(wall.position.z, newPos.z, percent));
                wall.transform.rotation = Quaternion.Lerp(wall.transform.rotation, Quaternion.Euler(newRot.x, newRot.y, newRot.z), percent);
                if(wall.transform.position == newPos && wall.transform.rotation == Quaternion.Euler(newRot.x, newRot.y, newRot.z))
                {
                    animating = false;
                    pressed = false;
                    howToUse = "Press " + keyToUse + " to close!";
                    GameManager.getInstance().addItemsInteract(this.name);
                }
            }
            else
            {
                float percent = (Time.time - startTime) / animationSpeed;
                wall.transform.position = new Vector3(Mathf.Lerp(wall.position.x, pos.x, percent), Mathf.Lerp(wall.position.y, pos.y, percent), Mathf.Lerp(wall.position.z, pos.z, percent));
                wall.transform.rotation = Quaternion.Lerp(wall.transform.rotation, rot, percent);
                if (wall.transform.position == pos && wall.transform.rotation == rot)
                {
                    howToUse = "Press " + keyToUse + " to open!";
                    animating = false;
                    pressed = false;
                    GameManager.getInstance().addItemsInteract(this.name);
                }
            }
        }
    }
}