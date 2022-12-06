using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuGroupButton : SelectableButton, IPointerClickHandler
{
    private MenuCharacterButton[] charButtons;

    [SerializeField]
    private TextMeshProUGUI buttonText;

    private bool isSetup = false;  //Hacky fix to prevent buttonAudio from playing on game start

    private void Awake()
    {
        this.charButtons = GetComponentsInChildren<MenuCharacterButton>();
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.DelaySetup());
    }

    private IEnumerator DelaySetup()
    {
        yield return null;

        this.isSetup = true;
    }

    private void AddGroupCharacters()
    {
        foreach (MenuCharacterButton charButton in this.charButtons)
        {
            if (charButton.curState == null || charButton.curState.GetType() == typeof(SelectedState))
            {
                continue;
            }

            charButton.ClickButton(true);
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

            charButton.ClickButton(true);
        }
    }

    public bool AllButtonsSelected()
    {
        bool allSelected = true;

        foreach (MenuCharacterButton charButton in this.charButtons)
        {
            if (charButton.curState == null || charButton.curState.GetType() == typeof(UnselectedState))
            {
                allSelected = false;
            }            
        }

        return allSelected;
    }

    public void NotifyMenuCharacterButtonClick()
    {
        if (this.curState == null)
        {
            return;
        }

        if (this.AllButtonsSelected() == true)            
        {
            if (this.curState.GetType() == typeof(UnselectedState))
            {
                this.ClickButton(true);
            }
        }
        else if (this.curState.GetType() == typeof(SelectedState))
        {
            this.ClickButton(true);
        }
    }
    
    public override void SelectBehavior()
    {
        if (this.virtualClick == false)
        {
            this.AddGroupCharacters();

            if (this.buttonAudio != null && this.isSetup == true)
            {
                this.buttonAudio.pitch = 1.5f;
                this.buttonAudio.Play();
            }
        }

        this.buttonText.text = "Unselect Group";
    }

    public override void UnselectBehavior()
    {
        if (this.virtualClick == false)
        {
            this.RemoveGroupCharacters();

            if (this.buttonAudio != null && this.isSetup == true)
            {
                this.buttonAudio.pitch = 0.5f;
                this.buttonAudio.Play();
            }
        }
        
        this.buttonText.text = "Select Group";
    }
}
