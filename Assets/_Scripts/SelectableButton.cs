using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject maskObject;
    public GameObject highlightObject;

    public ButtonState curState;

    [SerializeField]
    private AudioSource buttonAudio;

    public bool clicked = false;
    
    protected virtual void Start()
    {
        this.ChangeState(new UnselectedState());    
    }

    private void Update()
    {        
        this.curState.UpdateState();
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (this.buttonAudio != null)
        {
            this.buttonAudio.Play();
        }

        this.ClickButton();
    }

    public void ClickButton()
    {
        this.clicked = true;
    }

    public void ChangeState(ButtonState newState)
    {
        this.curState = newState;
        this.curState.Enter(this);

        this.clicked = false;
    }

    public virtual void SelectBehavior()
    { }

    public virtual void UnselectBehavior()
    { }

    public virtual void DisableBehavior()
    { }
}
