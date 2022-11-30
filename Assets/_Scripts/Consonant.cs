using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Consonant : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{    
    private string character;
    private TextMeshProUGUI consonantText;

    private LineRenderer dragLine;

    public bool dragging = false;

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

    public void OnPointerUp(PointerEventData data)
    {
        CharacterManager.consonant = string.Empty;
    }
}
