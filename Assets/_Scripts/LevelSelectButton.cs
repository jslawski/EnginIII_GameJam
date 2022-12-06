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
    private string consonant = string.Empty;
    
    [SerializeField]
    private GameObject maskObject;

    private TextMeshProUGUI charactersText;

    private List<string> associatedCharacters;

    private void Start()
    {
        this.Setup();

        if (this.charactersActive == true)
        {
            //Level.AddCharactersToLevel(this.consonant);
            this.maskObject.SetActive(false);
        }
    }

    private void Setup()
    {
        this.associatedCharacters = new List<string>
        {
            (this.consonant + "a"),
            (this.consonant + "i"),
            (this.consonant + "u"),
            (this.consonant + "e"),
            (this.consonant + "o"),
        };

        this.charactersText = GetComponentInChildren<TextMeshProUGUI>();        
        this.charactersText.text = this.GetJPCharacters();
    }

    private string GetJPCharacters()
    {
        string jpString = string.Empty;

        for (int i = 0; i < this.associatedCharacters.Count; i++)
        {
            if (this.associatedCharacters[i] != "yi" && this.associatedCharacters[i] != "ye")
            {
                jpString += TranslationDictionary.ENtoJP[this.associatedCharacters[i]];
            }
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
            //Level.AddCharactersToLevel(this.consonant);
            this.charactersActive = true;
        }
        else
        {
            //Level.RemoveCharactersFromLevel(this.consonant);
            this.charactersActive = false;
        }

        this.maskObject.SetActive(!this.charactersActive);
    }
}
