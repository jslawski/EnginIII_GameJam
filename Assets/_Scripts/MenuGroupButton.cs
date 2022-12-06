using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuGroupButton : SelectableButton, IPointerClickHandler
{
    private MenuCharacterButton[] charButtons;

    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        this.charButtons = GetComponentsInChildren<MenuCharacterButton>();
        this.buttonText = GetComponent<TextMeshProUGUI>();
    }

    private void AddGroupCharacters()
    {
        foreach (MenuCharacterButton charButton in this.charButtons)
        {
            if (charButton.curState.GetType() == typeof(SelectedState))
            {
                continue;
            }

            charButton.ClickButton();
        }
    }

    private void RemoveGroupCharacters()
    {
        foreach (MenuCharacterButton charButton in this.charButtons)
        {
            if (charButton.curState == null || charButton.curState.GetType() == typeof(UnselectedState))
            {
                continue;
            }

            charButton.ClickButton();
        }
    }

    public override void SelectBehavior()
    {
        this.AddGroupCharacters();
    }

    public override void UnselectBehavior()
    {
        this.RemoveGroupCharacters();
    }
}
