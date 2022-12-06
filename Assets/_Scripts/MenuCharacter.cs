using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacter
{
    public const int MASTERY_TARGET = 20;

    public string enChar;
    public string jpChar;
    public int curMastery;
    public float masteryPercentage;
    public bool mastered;
    
    public MenuCharacter(string englishChar)
    {
        this.enChar = englishChar;
        this.jpChar = TranslationDictionary.ENtoJP[this.enChar];
        this.curMastery = PlayerPrefs.GetInt(this.enChar, 0);
        this.masteryPercentage = ((float)this.curMastery / (float)MASTERY_TARGET);
        this.mastered = (this.curMastery >= MASTERY_TARGET) ? true : false;
    }
}
