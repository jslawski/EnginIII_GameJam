using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    protected SelectableButton controller;

    public virtual void Enter(SelectableButton buttonController)
    {
        this.controller = buttonController;
    }
    public virtual void UpdateState() { }
}
