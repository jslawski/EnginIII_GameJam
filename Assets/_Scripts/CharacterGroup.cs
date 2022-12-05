using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroupTrigger { Selected, Unselected }

public class CharacterGroup : MonoBehaviour
{
    private CharacterObject[] charObjects;
    
    // Start is called before the first frame update
    void Start()
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
                charObj.SelectObject();
            }
            else
            {
                charObj.DisableObject();
            }            
        }
    }

    private void OnCharacterUnselected()
    {
        foreach (CharacterObject charObj in this.charObjects)
        {
            charObj.UnselectObject();
        }
    }
}
