using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterBlock : MonoBehaviour
{
    public string ENCharacter;
    public string JPCharacter;

    [SerializeField]
    private TextMeshProUGUI blockText;

    public void Setup()
    {
        int randomIndex = Random.Range(0, Level.levelCharacters_JP.Count);
        string randomCharacter = Level.levelCharacters_JP[randomIndex];

        //Skip yi and ye
        while (randomCharacter == "yi" || randomCharacter == "ye")
        {
            randomIndex = Random.Range(0, Level.levelCharacters_JP.Count);
            randomCharacter = Level.levelCharacters_JP[randomIndex];
        }

        this.blockText.text = randomCharacter;

        this.ENCharacter = TranslationDictionary.JPtoEN[randomCharacter];
        this.JPCharacter = randomCharacter;

        GetComponent<Transform>().SetAsFirstSibling();
    }

    public void SwapToEnglish()
    {
        this.blockText.text = ENCharacter.ToUpper();
    }
}
