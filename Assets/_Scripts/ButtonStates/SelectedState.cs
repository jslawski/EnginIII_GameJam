using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedState : ButtonState
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
            this.controller.selectedMask.SetActive(true);
        }

        if (this.controller.disabledMask != null)
        {
            this.controller.disabledMask.SetActive(false);
        }

        this.controller.SelectBehavior();
    }


    public override void UpdateState()
    {
        base.UpdateState();

        if (this.controller.clicked == true)
        {            
            this.controller.ChangeState(new UnselectedState());
        }
    }
}
