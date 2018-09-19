using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCoolDown = 1f;
    public string description = "";

    public abstract void Initialize(GameObject obj);
    public abstract bool TriggerAbility();
}
