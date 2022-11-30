using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Consonant : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private string character;
    private TextMeshProUGUI consonantText;

    private void Awake()
    {
        this.Setup(character);
    }

    private void Setup(string character)
    {
        this.consonantText = GetComponentInChildren<TextMeshProUGUI>();
        this.consonantText.text = character.ToUpper();
    }

    public void OnPointerClick(PointerEventData data)
    {
        CharacterManager.consonant = this.character.ToLower();
    }
}
