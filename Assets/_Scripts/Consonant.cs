using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Consonant : MonoBehaviour, IPointerDownHandler
{    
    private string character;
    private TextMeshProUGUI consonantText;
    
    public void Setup(string character)
    {
        this.character = character;

        this.consonantText = GetComponentInChildren<TextMeshProUGUI>();
        this.consonantText.text = character.ToUpper();
    }

    public void OnPointerDown(PointerEventData data)
    {
        CharacterManager.consonant = this.character.ToLower();
    }
}
