using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject unselectedMask;
    public GameObject selectedMask;
    public GameObject disabledMask;

    public ButtonState curState;

    [SerializeField]
    protected AudioSource buttonAudio;

    [HideInInspector]
    public bool clicked = false;
    [HideInInspector]
    public bool virtualClick = false;
    [HideInInspector]
    public bool disabled = false;

    protected virtual void Start()
    {
        this.ChangeState(new UnselectedState());    
    }

    private void Update()
    {        
        this.curState.UpdateState();
    }

    public virtual void OnPointerClick(PointerEventData data)
    {
        if (this.buttonAudio != null)
        {
            this.buttonAudio.Play();
        }

        this.ClickButton();
    }

    public virtual void ClickButton(bool isVirtual = false)
    {
        this.clicked = true;
        this.virtualClick = isVirtual;
    }

    public void ChangeState(ButtonState newState)
    {
        this.curState = newState;
        this.curState.Enter(this);

        this.clicked = false;
        this.virtualClick = false;
    }

    public virtual void SelectBehavior()
    { }

    public virtual void UnselectBehavior()
    { }

    public virtual void DisableBehavior()
    { }
}
