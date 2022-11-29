using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CharacterStack charStack;
    
    private void Start()
    {
        this.SetupGame();  
    }

    private void SetupGame()
    {
        TranslationDictionary.Setup();
        this.SetupTestLevel();
        this.StartLevel();
    }

    private void SetupTestLevel()
    {
        List<string> testList = new List<string>() 
        { 
            "a", "i", "u", "e", "o",
            "ka", "ki", "ku", "ke", "ko"
        };
        Level.SetupNewLevel(testList, 1.0f);
    }

    private void StartLevel()
    {
        this.charStack.BeginGeneration();
    }
}
