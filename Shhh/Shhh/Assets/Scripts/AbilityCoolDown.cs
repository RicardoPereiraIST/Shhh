using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityCoolDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public GameObject childText;

    void Start()
    {
        childText.GetComponent<Text>().text = ability.description;
        childText.SetActive(false);
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
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
            if (Input.GetKeyDown(abilityKey) && !this.name.Equals("Distraction"))
            {
                GameManager.getInstance().addAbilityAttempt(this.name);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2) && this.name.Equals("Distraction"))
            {
                GameManager.getInstance().addAbilityAttempt(this.name);
            }
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
            GameManager.getInstance().addAbilityUsage(this.name);
        }
    }

    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        childText.SetActive(true);
    }
    public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        childText.SetActive(false);
    }
}