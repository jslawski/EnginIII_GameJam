using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroupTrigger { Selected, Unselected, Disabled }

public class CharacterGroup : MonoBehaviour
{
    [HideInInspector]
    public CharacterObject[] charObjects;
    
    void Awake()
    {
        this.charObjects = GetComponentsInChildren<CharacterObject>();
    }

    public void OnNotify(CharacterObject groupObject, GroupTrigger trigger)
    {
        switch (trigger)
        {
            case GroupTrigger.Selected:
                this.OnCharacterSelected(groupObject);
                break;
            case GroupTrigger.Unselected:
                this.OnCharacterUnselected();
                break;
            case GroupTrigger.Disabled:                
                break;
            default:
                Debug.LogError("Unknown trigger: " + trigger.ToString() + ". Unable to update group.");
                return;
        }
    }

    private void OnCharacterSelected(CharacterObject selectedObject)
    {
        foreach (CharacterObject charObj in this.charObjects)
        {
            if (charObj == selectedObject)
            {
                charObj.ChangeState(new SelectedState());
            }
            else
            {
                charObj.disabled = true;
            }            
        }
    }

    private void OnCharacterUnselected()
    {
        foreach (CharacterObject charObj in this.charObjects)
        {
            charObj.disabled = false;
            charObj.ChangeState(new UnselectedState());
        }
    }
}
