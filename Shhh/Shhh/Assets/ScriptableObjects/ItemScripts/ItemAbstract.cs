using UnityEngine;

public abstract class ItemAbstract : ScriptableObject
{
    public string iName = "New Item";
    public string iDescription = "Press X";
    public KeyCode itemKey;
    public string itemDescription = "";

    public Sprite iSprite;
    public AudioClip iSound;
    public float iBaseCoolDown = 1f;

    public bool isMultiUse;
    public int maxStack;

    public bool showMessage = false;
    public bool showIcon;
    public bool isInteractable;

    public abstract void Initialize();
    public abstract bool CanUseItem();
    public abstract bool PickUpItem();
    public abstract void UseItem();
    public abstract int getNumberOfItems();
}
