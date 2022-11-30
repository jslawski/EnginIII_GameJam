using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Vowel : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField]
    private string character;
    private TextMeshProUGUI vowelText;

    private void Awake()
    {
        this.vowelText = GetComponentInChildren<TextMeshProUGUI>();
        this.vowelText.text = character.ToUpper();
    }

    public void OnPointerClick(PointerEventData data)
    {
        CharacterManager.vowel = this.character.ToLower();
    }

    public void OnPointerEnter(PointerEventData data)
    {        
        if (CharacterManager.consonant != string.Empty)
        {            
            CharacterManager.vowel = this.character.ToLower();            
        }
    }    
}
