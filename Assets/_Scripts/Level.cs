using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Level
{
    public static List<string> levelCharacters_JP;
    public static float timeBetweenBlocks = 1.0f;

    public static void AddCharactersToLevel(List<string> enCharacters)
    {
        if (levelCharacters_JP == null)
        {
            levelCharacters_JP = new List<string>();
        }

        for (int i = 0; i < enCharacters.Count; i++)
        {
            levelCharacters_JP.Add(TranslationDictionary.ENtoJP[enCharacters[i]]);
        }
    }

    public static void RemoveCharactersFromLevel(List<string> enCharacters)
    {
        for (int i = 0; i < enCharacters.Count; i++)
        {
            levelCharacters_JP.Remove(TranslationDictionary.ENtoJP[enCharacters[i]]);
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
