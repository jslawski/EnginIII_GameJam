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

    public static void AddCharactersToLevel(string consonant)
    {        
        levelCharacters_JP.Add(TranslationDictionary.ENtoJP[(consonant + "a")]);
        levelCharacters_JP.Add(TranslationDictionary.ENtoJP[(consonant + "i")]);
        levelCharacters_JP.Add(TranslationDictionary.ENtoJP[(consonant + "u")]);
        levelCharacters_JP.Add(TranslationDictionary.ENtoJP[(consonant + "e")]);
        levelCharacters_JP.Add(TranslationDictionary.ENtoJP[(consonant + "o")]);

        if (consonant != string.Empty)
        {
            activeConsonants.Add(consonant);
        }
    }

    public static void RemoveCharactersFromLevel(string consonant)
    {
        levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[(consonant + "a")]);
        levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[(consonant + "i")]);
        levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[(consonant + "u")]);
        levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[(consonant + "e")]);
        levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[(consonant + "o")]);

        if (consonant != string.Empty)
        {
            activeConsonants.Remove(consonant);
        }
    }

    public static void SetupNewLevel(List<string> enCharacters, float blockTime = 5.0f)
    {
        CreateJPCharList(enCharacters);
        timeBetweenBlocks = blockTime;
    }

    private static void CreateJPCharList(List<string> enCharacters)
    {
        levelCharacters_JP = new List<string>();

        for (int i = 0; i < enCharacters.Count; i++)
        {
            levelCharacters_JP.Add(TranslationDictionary.ENtoJP[enCharacters[i]]);
        }
    }
}
