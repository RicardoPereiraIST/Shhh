using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public string abilityButtonAxisName = "";
    public Image darkMask;
    public Text coolDownTextDisplay;
    public Text stackTextDisplay;

    [SerializeField]
    public ItemAbstract item;

    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    protected float coolDownTimeLeft;

    public GameObject childText;

    void Start()
    {
        childText.GetComponent<Text>().text = item.itemDescription;
        childText.SetActive(false);
        Initialize(item);
    }

    public void Initialize(ItemAbstract selectedItem)
    {
        item = selectedItem;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = item.iSprite;
        darkMask.sprite = item.iSprite;
        coolDownDuration = item.iBaseCoolDown;
        item.Initialize();
        ItemReady();
        GetComponent<Image>().enabled = item.showIcon;
    }

    private void OnGUI()
    {
        if (item.showMessage)
        {
            GUIContent content = new GUIContent(item.iDescription);
            GUIStyle style = GUI.skin.box;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.MiddleCenter;
            Vector2 size = style.CalcSize(content);
            //GUI.Label(new Rect(10, 10, 2.0f * size.x, 2.0f * size.y), content, style);
            GUI.Label(new Rect(Screen.width / 2 - 225, Screen.height / 2 - 100, 2.0f * size.x, 2.0f * size.y), content, style);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            ItemReady();
            if (!item.isInteractable && item.CanUseItem() && Input.GetKeyDown(item.itemKey))
            {
                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
        GetComponent<Image>().enabled = item.showIcon;
    }

    private void ItemReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;

        if (item.isMultiUse)
        {
            stackTextDisplay.enabled = item.showIcon;
            stackTextDisplay.text = item.getNumberOfItems().ToString();
        }
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
        if (item.isMultiUse)
        {
            stackTextDisplay.text = item.getNumberOfItems().ToString();
            stackTextDisplay.enabled = item.showIcon;
        }
        coolDownTextDisplay.enabled = item.showIcon;
        darkMask.enabled = item.showIcon;
    }

    private void ButtonTriggered()
    {
        item.UseItem();

        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        if(item.isMultiUse)
        {
            stackTextDisplay.text = item.getNumberOfItems().ToString();
        }

        abilitySource.clip = item.iSound;
        abilitySource.Play();
        GameManager.getInstance().addItemsUsed(this.name);
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
