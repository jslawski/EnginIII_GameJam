using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CharacterStack charStack;

    [SerializeField]
    private int score = 0;

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

    private void Update()
    {
        if (CharacterManager.vowel != string.Empty)
        {
            this.ProcessEntry();
        }
    }

    private void SetupTestLevel()
    {
        List<string> testList = new List<string>() 
        { 
            "a", "i", "u", "e", "o"            
        };
        Level.SetupNewLevel(testList, 1.0f);
    }

    private void StartLevel()
    {
        this.charStack.BeginGeneration();
    }

    private void ProcessEntry()
    {
        string characterEntry = CharacterManager.consonant + CharacterManager.vowel;
        bool result = this.charStack.ProcessEntry(characterEntry);

        if (result == true)
        {
            this.score++;
        }

        CharacterManager.consonant = string.Empty;
        CharacterManager.vowel = string.Empty;
    }
}
