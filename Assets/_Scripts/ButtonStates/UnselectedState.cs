using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnselectedState : ButtonState
{
    public override void Enter(SelectableButton buttonController)
    {
        base.Enter(buttonController);

        if (this.controller.unselectedMask != null)
        {
            this.controller.unselectedMask.SetActive(true);
        }

        if (this.controller.selectedMask != null)
        {
            this.controller.selectedMask.SetActive(false);
        }

        if (this.controller.disabledMask != null)
        {
            this.controller.disabledMask.SetActive(false);
        }

        this.controller.UnselectBehavior();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (this.controller.clicked == true)
        {            
            this.controller.ChangeState(new SelectedState());
        }
    }
}
