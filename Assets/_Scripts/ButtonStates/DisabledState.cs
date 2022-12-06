using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledState : ButtonState
{
    public override void Enter(SelectableButton buttonController)
    {
        base.Enter(buttonController);

        this.controller.maskObject.SetActive(false);

        if (this.controller.highlightObject != null)
        {
            this.controller.highlightObject.SetActive(false);
        }

        this.controller.DisableBehavior();
    }


    public override void UpdateState()
    {
        if (this.controller.clicked == true)
        {            
            this.controller.ChangeState(new SelectedState());
        }
    }
}
