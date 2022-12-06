using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterObject : SelectableButton
{
    public string enChar;
    public bool isVowel;

    [SerializeField]
    private TextMeshProUGUI charUI;
    [SerializeField]
    private SpriteRenderer bgSprite;
    
    private Collider objCollider;
    private CharacterGroup charGroup;

    private void Awake()
    {
        this.charGroup = GetComponentInParent<CharacterGroup>();
        this.objCollider = GetComponent<Collider>();
    }

    protected override void Start()
    {
        base.Start();
        
        if (this.isVowel == true)
        {
            this.bgSprite.sprite = Resources.Load<Sprite>("Sprites/blueCircle");
        }
        else
        {
            this.bgSprite.sprite = Resources.Load<Sprite>("Sprites/purpleCircle");
        }
    }

    public void Setup(string newChar, bool vowel)
    {
        this.enChar = newChar;
        this.isVowel = vowel;
        this.charUI = GetComponentInChildren<TextMeshProUGUI>();
        this.charUI.text = newChar.ToUpper();        
    }

    public void UpdateStatus(GroupTrigger newStatus)
    {
        if (newStatus == GroupTrigger.Disabled)
        {
            this.disabled = true;
        }
        else
        {
            this.disabled = false;
        }
        
        this.charGroup.OnNotify(this, newStatus);
    }

    public override void ClickButton(bool isVirtual = false)
    {
        base.ClickButton(isVirtual);

        if (this.buttonAudio != null)
        {
            this.buttonAudio.Play();
        }
    }

    public override void UnselectBehavior()
    {
        this.objCollider.enabled = true;
    }

    public override void DisableBehavior()
    {
        this.objCollider.enabled = false;
    }

    /*
    public void SelectObject()
    {
        this.selectedSprite.SetActive(true);
        this.disabledSprite.SetActive(false);
    }

    public void UnselectObject()
    {
        this.selectedSprite.SetActive(false);
        this.disabledSprite.SetActive(false);
        this.objCollider.enabled = true;
    }

    public void DisableObject()
    {
        this.selectedSprite.SetActive(false);
        this.disabledSprite.SetActive(true);
        this.objCollider.enabled = false;
    }
    */
}
