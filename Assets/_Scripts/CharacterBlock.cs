using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterBlock : MonoBehaviour
{
    private string ENCharacter;
    private string JPCharacter;

    [SerializeField]
    private TextMeshProUGUI blockText;

    public void Setup()
    {
        int randomIndex = Random.Range(0, Level.levelCharacters_JP.Count);
        string randomCharacter = Level.levelCharacters_JP[randomIndex];
        this.blockText.text = randomCharacter;

        GetComponent<Transform>().SetAsFirstSibling();
    }
}
