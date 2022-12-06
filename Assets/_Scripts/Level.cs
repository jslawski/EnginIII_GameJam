using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level
{
    public static List<string> levelCharacters_JP;
    public static List<string> activeConsonants;
    public static float timeBetweenBlocks = 3.0f;

    public static void Setup()
    {
        levelCharacters_JP = new List<string>();
        activeConsonants = new List<string>();
    }

    public static void AddCharacterToLevel(string character)
    {
        string characterJP = TranslationDictionary.ENtoJP[character];

        if (levelCharacters_JP.Contains(characterJP))
        {
            return;
        }
        
        if (character.Length > 1)
        {
            string consonant = character[0].ToString();
            if (activeConsonants.Contains(consonant) == false)
            {
                activeConsonants.Add(consonant);
            }
        }

        levelCharacters_JP.Add(characterJP);
    }

    public static void RemoveCharacterFromLevel(string character)
    {
        string characterJP = TranslationDictionary.ENtoJP[character];

        if (levelCharacters_JP.Contains(characterJP) == false)
        {
            return;
        }

        if (character.Length > 1)
        {
            string consonant = character[0].ToString();
            if (activeConsonants.Contains(consonant) == true)
            {
                activeConsonants.Remove(consonant);
            }
        }

        levelCharacters_JP.Remove(characterJP);
    }
}
