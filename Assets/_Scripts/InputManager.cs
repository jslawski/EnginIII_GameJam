using UnityEngine;

public class InputManager : MonoBehaviour
{
    private CharacterObject vowelChar;
    private CharacterObject consonantChar;

    private bool isDragging = false;
    private Vector3 inputScreenPosition = Vector3.zero;

    [SerializeField]
    private CharacterStack charStack;
    [SerializeField]
    private InputObserver inputObserver;

    // Update is called once per frame
    void Update()
    {
        this.inputScreenPosition = Vector3.zero;
        this.isDragging = false;

        this.HandleTouchInput();
        this.HandleMouseInput();

        this.ProcessInput();
    }

    private CharacterObject GetObjectAtPosition(Vector3 screenSpacePosition)
    {
        RaycastHit hitInfo;
        Ray inputRay = Camera.main.ScreenPointToRay(screenSpacePosition);

        if (Physics.Raycast(inputRay, out hitInfo))
        {
            if (hitInfo.transform.tag == "CharObject")
            {
                return hitInfo.transform.gameObject.GetComponent<CharacterObject>();
            }
        }

        return null;
    }

    private void ProcessInput()
    {
        if (this.isDragging == false)
        {
            if (this.vowelChar != null)
            {
                this.SubmitInput();
            }

            this.ClearInputChars();
            return;
        }

        CharacterObject inputChar = this.GetObjectAtPosition(this.inputScreenPosition);

        if (inputChar != null)
        {
            this.SelectInputChar(inputChar);
        }
        else if (this.vowelChar != null)
        {
            this.UnselectVowelChar();
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {            
            this.isDragging = true;
            this.inputScreenPosition = Input.GetTouch(0).position;
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(0) == true)
        {
            this.isDragging = true;
            this.inputScreenPosition = Input.mousePosition;
        }
    }

    private void SelectInputChar(CharacterObject newChar)
    {
        if (newChar.isVowel == true)
        {            
            this.vowelChar = newChar;
            this.vowelChar.UpdateStatus(GroupTrigger.Selected);
        }
        else
        {
            this.consonantChar = newChar;
            this.consonantChar.UpdateStatus(GroupTrigger.Selected);
        }
    }

    private void UnselectVowelChar()
    {
        this.vowelChar.UpdateStatus(GroupTrigger.Unselected);
        this.vowelChar = null;
    }

    private void SubmitInput()
    {
        string fullChar = string.Empty;

        if (this.consonantChar != null)
        {
            fullChar += this.consonantChar.enChar;
        }

        fullChar += this.vowelChar.enChar;        

        bool result = this.charStack.ProcessEntry(fullChar);
        this.inputObserver.OnNotify(fullChar, result);
    }

    private void ClearInputChars()
    {
        if (this.vowelChar != null)
        {
            this.vowelChar.UpdateStatus(GroupTrigger.Unselected);
            this.vowelChar = null;
        }
        if (this.consonantChar != null)
        {
            this.consonantChar.UpdateStatus(GroupTrigger.Unselected);
            this.consonantChar = null;
        }
    }    
}
