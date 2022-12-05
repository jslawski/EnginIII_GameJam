using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    public string enChar;
    public bool isVowel;

    [SerializeField]
    private TextMeshProUGUI charUI;
    [SerializeField]
    private SpriteRenderer bgSprite;
    [SerializeField]
    private GameObject disabledSprite;
    [SerializeField]
    private GameObject selectedSprite;

    private CharacterGroup charGroup;

    private void Start()
    {
        this.charGroup = GetComponentInParent<CharacterGroup>();

        if (this.isVowel == true)
        {
            this.bgSprite.sprite = Resources.Load<Sprite>("Sprites/blueCircle");
        }
        else
        {
            this.bgSprite.sprite = Resources.Load<Sprite>("Sprites/purpleCircle");
        }
    }

    public virtual void Setup(string newChar, bool vowel)
    {
        this.enChar = newChar;
        this.isVowel = vowel;
        this.charUI = GetComponentInChildren<TextMeshProUGUI>();
        this.charUI.text = newChar.ToUpper();        
    }

    public void UpdateStatus(GroupTrigger newStatus)
    {
        this.charGroup.OnNotify(this, newStatus);
    }

    public void SelectObject()
    {
        this.selectedSprite.SetActive(true);
        this.disabledSprite.SetActive(false);        
    }

    public void UnselectObject()
    {
        this.selectedSprite.SetActive(false);
        this.disabledSprite.SetActive(false);        
    }

    public void DisableObject()
    {
        this.selectedSprite.SetActive(false);
        this.disabledSprite.SetActive(true);
    }
}
