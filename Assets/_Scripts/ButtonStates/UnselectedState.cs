using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnselectedState : ButtonState
{
    public override void Enter(SelectableButton buttonController)
    {
        base.Enter(buttonController);

        this.controller.maskObject.SetActive(true);

        if (this.controller.highlightObject != null)
        {
            this.controller.highlightObject.SetActive(false);
        }

        this.controller.UnselectBehavior();
    }

    public override void UpdateState()
    {
        if (this.controller.clicked == true)
        {            
            this.controller.ChangeState(new SelectedState());
        }
    }
}
