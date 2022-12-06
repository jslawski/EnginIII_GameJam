using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCharacterButton : SelectableButton
{
    private MenuCharacter charData;

    [SerializeField]
    private TextMeshProUGUI charText;
    [SerializeField]
    private Image masteryFillImage;
    [SerializeField]
    private GameObject masteryStar;

    private MenuGroupButton groupButton;

    private bool isSetup = false;  //Hacky fix to prevent buttonAudio from playing on game start

    protected override void Start()
    {
        this.groupButton = GetComponentInParent<MenuGroupButton>();

        base.Start();
                
        //Automatically enable if vowel
        if (this.charData.enChar.Length == 1)
        {
            this.ClickButton();
        }

        StartCoroutine(this.DelaySetup());
    }

    private IEnumerator DelaySetup()
    {
        yield return null;

        this.isSetup = true;
    }

    public void Setup(string enChar)
    {
        this.charData = new MenuCharacter(enChar);        

        this.charText.text = this.charData.jpChar;
        this.masteryFillImage.fillAmount = this.charData.masteryPercentage;
        this.masteryStar.SetActive(this.charData.mastered);

        if (this.charData.enChar == "yi" || this.charData.enChar == "ye")
        {
            this.gameObject.SetActive(false);
        }        
    }

    public override void SelectBehavior()
    {
        Level.AddCharacterToLevel(this.charData.enChar);

        if (this.virtualClick == false)
        {
            this.groupButton.NotifyMenuCharacterButtonClick();

            if (this.buttonAudio != null && this.isSetup == true)
            {
                this.buttonAudio.pitch = 1.5f;
                this.buttonAudio.Play();
            }
        }

    }

    public override void UnselectBehavior()
    {        
        Level.RemoveCharacterFromLevel(this.charData.enChar);

        if (this.virtualClick == false)
        {
            this.groupButton.NotifyMenuCharacterButtonClick();

            if (this.buttonAudio != null && this.isSetup == true)
            {
                this.buttonAudio.pitch = 0.5f;
                this.buttonAudio.Play();
            }
        }
    }    
}
