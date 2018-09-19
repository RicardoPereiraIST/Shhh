using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
    public KeyCode abilityKey;
    //public string abilityButtonAxisName = "";
    public Image darkMask;
    public Text coolDownTextDisplay;

    [SerializeField]
    public Ability ability;
    [SerializeField]
    private GameObject holder;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    protected float coolDownTimeLeft;

    void Start()
    {
        Initialize(ability, holder);
    }

    public void Initialize(Ability selectedAbility, GameObject holder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(holder);
        AbilityReady();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetKeyDown(abilityKey))
            {
                GameManager.getInstance().addAbilityUsage(ability);
                ButtonTriggered();
            }
        }
        else
        {
            if (Input.GetKeyDown(abilityKey))
            {
                GameManager.getInstance().addAbilityAttempt(ability);
            }
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
    }

    private void ButtonTriggered()
    {
        if(ability.TriggerAbility())
        { 
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownTextDisplay.enabled = true;

            abilitySource.clip = ability.aSound;
            abilitySource.Play();
        }
    }
}