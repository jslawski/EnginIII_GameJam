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

    private static bool ContainsSameConsonant(string consonant)
    {
        for (int i = 0; i < levelCharacters_JP.Count; i++)
        {
            string enCharacter = TranslationDictionary.JPtoEN[levelCharacters_JP[i]];

            if (enCharacter[0].ToString() == consonant)
            {
                return true;
            }
        }

        return false;
    }

    public static void RemoveCharacterFromLevel(string character)
    {
        string characterJP = TranslationDictionary.ENtoJP[character];

        if (levelCharacters_JP.Contains(characterJP) == false)
        {
            return;
        }

        levelCharacters_JP.Remove(characterJP);

        if (character.Length > 1)
        {
            string consonant = character[0].ToString();
            if (activeConsonants.Contains(consonant) == true && 
                ContainsSameConsonant(consonant) == false)
            {
                activeConsonants.Remove(consonant);
            }
        }        
    }
}
