using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item {

    // Use this for initialization
    void Start()
    {
        aName = "key";
        pickable = true;
        howToUse = "Press " + keyToUse.ToString() + " to pick up key";
    }
}
