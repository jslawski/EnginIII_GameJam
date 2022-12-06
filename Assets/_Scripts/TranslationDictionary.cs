using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TranslationDictionary
{
    public static Dictionary<string, string> ENtoJP;
    public static Dictionary<string, string> JPtoEN;

    public static List<string> ENList;
    public static List<string> JPList;

    public static void Setup()
    {
        SetupENtoJP();
        SetupJPtoEN();

        SetupENList();
        SetupJPList();
    }

    private static void SetupENtoJP()
    {
        ENtoJP = new Dictionary<string, string>();

        ENtoJP.Add("a", "あ");
        ENtoJP.Add("i", "い");
        ENtoJP.Add("u", "う");
        ENtoJP.Add("e", "え");
        ENtoJP.Add("o", "お");

        ENtoJP.Add("ka", "か");
        ENtoJP.Add("ki", "き");
        ENtoJP.Add("ku", "く");
        ENtoJP.Add("ke", "け");
        ENtoJP.Add("ko", "こ");

        ENtoJP.Add("sa", "さ");
        ENtoJP.Add("si", "し");
        ENtoJP.Add("su", "す");
        ENtoJP.Add("se", "せ");
        ENtoJP.Add("so", "そ");

        ENtoJP.Add("ta", "た");
        ENtoJP.Add("ti", "ち");
        ENtoJP.Add("tu", "つ");
        ENtoJP.Add("te", "て");
        ENtoJP.Add("to", "と");

        ENtoJP.Add("ra", "ら");
        ENtoJP.Add("ri", "り");
        ENtoJP.Add("ru", "る");
        ENtoJP.Add("re", "れ");
        ENtoJP.Add("ro", "ろ");

        ENtoJP.Add("ha", "は");
        ENtoJP.Add("hi", "ひ");
        ENtoJP.Add("hu", "ふ");
        ENtoJP.Add("he", "へ");
        ENtoJP.Add("ho", "ほ");

        ENtoJP.Add("na", "な");
        ENtoJP.Add("ni", "に");
        ENtoJP.Add("nu", "ぬ");
        ENtoJP.Add("ne", "ね");
        ENtoJP.Add("no", "の");

        ENtoJP.Add("ma", "ま");
        ENtoJP.Add("mi", "み");
        ENtoJP.Add("mu", "む");
        ENtoJP.Add("me", "め");
        ENtoJP.Add("mo", "も");

        ENtoJP.Add("ya", "や");
        ENtoJP.Add("yi", "yi");
        ENtoJP.Add("yu", "ゆ");
        ENtoJP.Add("ye", "ye");
        ENtoJP.Add("yo", "よ");
    }

    private static void SetupJPtoEN()
    {
        JPtoEN = new Dictionary<string, string>();
        
        foreach (KeyValuePair<string, string> entry in ENtoJP)
        {
            JPtoEN.Add(entry.Value, entry.Key);
        }
    }

    private static void SetupENList()
    {
        ENList = new List<string>();

        foreach (KeyValuePair<string, string> entry in ENtoJP)
        {
            ENList.Add(entry.Key);
        }
    }

    private static void SetupJPList()
    {
        JPList = new List<string>();

        foreach (KeyValuePair<string, string> entry in ENtoJP)
        {
            JPList.Add(entry.Value);
        }
    }
}
