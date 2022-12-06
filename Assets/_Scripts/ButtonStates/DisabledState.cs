using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledState : ButtonState
{
    public override void Enter(SelectableButton buttonController)
    {
        base.Enter(buttonController);

        if (this.controller.unselectedMask != null)
        {
            this.controller.unselectedMask.SetActive(false);
        }
        
        if (this.controller.selectedMask != null)
        {
            this.controller.selectedMask.SetActive(false);
        }

        if (this.controller.disabledMask != null)
        {
            this.controller.disabledMask.SetActive(true);
        }

        this.controller.DisableBehavior();
    }


    public override void UpdateState()
    {
        base.UpdateState();

        if (this.controller.disabled == false)
        {            
            this.controller.ChangeState(new UnselectedState());
        }
    }
}
