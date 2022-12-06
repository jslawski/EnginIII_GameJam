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

    private bool playedSelectedSound = false;

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

    public override void SelectBehavior()
    {
        if (this.buttonAudio != null && this.playedSelectedSound == false)
        {
            this.buttonAudio.pitch = Random.Range(0.5f, 1.5f);
            this.buttonAudio.Play();
            this.playedSelectedSound = true;
        }
    }

    public override void UnselectBehavior()
    {
        this.playedSelectedSound = false;
        this.objCollider.enabled = true;        
    }

    public override void DisableBehavior()
    {
        this.objCollider.enabled = false;
        this.playedSelectedSound = false;
    }
}
