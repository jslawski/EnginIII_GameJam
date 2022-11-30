using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LevelSelectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private bool charactersActive = false;

    [SerializeField]
    private List<string> associatedCharacters;
    
    [SerializeField]
    private GameObject maskObject;

    private TextMeshProUGUI charactersText;

    private void Start()
    {
        this.Setup();

        if (this.charactersActive == true)
        {
            Level.AddCharactersToLevel(this.associatedCharacters);
            this.maskObject.SetActive(false);
        }
    }

    private void Setup()
    {
        this.charactersText = GetComponentInChildren<TextMeshProUGUI>();
        this.charactersText.text = this.GetJPCharacters();
    }

    private string GetJPCharacters()
    {
        string jpString = string.Empty;

        for (int i = 0; i < this.associatedCharacters.Count; i++)
        {
            jpString += TranslationDictionary.ENtoJP[this.associatedCharacters[i]];
        }

        return jpString;
    }

    public void OnPointerClick(PointerEventData data)
    {
        this.ToggleCharacters();
    }

    private void ToggleCharacters()
    {
        if (this.charactersActive == false)
        {
            Level.AddCharactersToLevel(this.associatedCharacters);
            this.charactersActive = true;
        }
        else
        {
            Level.RemoveCharactersFromLevel(this.associatedCharacters);
            this.charactersActive = false;
        }

        this.maskObject.SetActive(!this.charactersActive);
    }
}
