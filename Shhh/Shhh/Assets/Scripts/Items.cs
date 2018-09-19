using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public string aName;
    protected string howToUse;
    public bool isTrigger = false;
    public KeyCode keyToUse;
    public bool pickable;
    public Ability ability;

    private void Start()
    {
        if(pickable)
            howToUse = "Press " + keyToUse.ToString() + " to pick up key";
        else
            howToUse = "Press " + keyToUse.ToString() + " to use";
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

    public virtual void doItem()
    {
        ability.TriggerAbility();
    }
}
