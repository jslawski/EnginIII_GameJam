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
    }

    public override void UnselectBehavior()
    {        
        Level.RemoveCharacterFromLevel(this.charData.enChar);
    }    
}