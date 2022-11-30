using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    void Awake()
    {
        TranslationDictionary.Setup();
        Level.Setup();
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }
}
