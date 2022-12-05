using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private GameObject gameOverCanvas;


    [SerializeField]
    private CharacterGroup vowelCharacterGroup;
    [SerializeField]
    private CharacterGroup[] consonantCharacterGroups;

    private void Start()
    {
        this.SetupGame();
    }

    private void SetupGame()
    {
        this.SetupVowels();
        this.SetupConsonants();
    }

    private void SetupVowels()
    {
        foreach (CharacterObject charObj in this.vowelCharacterGroup.charObjects)
        {
            charObj.Setup(charObj.enChar, true);
        }
    }

    private void SetupConsonants()
    {
        if (Level.activeConsonants.Count < 1)
        {
            return;
        }

        CharacterGroup activeGroup = this.consonantCharacterGroups[Level.activeConsonants.Count - 1];
        activeGroup.gameObject.SetActive(true);        

        for (int i = 0; i < Level.activeConsonants.Count; i++)
        {
            activeGroup.charObjects[i].Setup(Level.activeConsonants[i], false);
        }        
    }

    private void Update()
    {        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TriggerGameOver()
    {
        this.gameOverCanvas.SetActive(true);
    }
}
