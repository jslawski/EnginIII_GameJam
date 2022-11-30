using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private TextMeshProUGUI startText;

    void Awake()
    {
        Screen.SetResolution(540, 960, false);
        Screen.fullScreen = false;

        TranslationDictionary.Setup();
        Level.Setup();
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Level.activeConsonants.Count > 4)
        {
            this.startButton.interactable = false;
            this.startText.text = "Too many characters!";
        }
        else if (Level.levelCharacters_JP.Count <= 0)
        {
            this.startButton.interactable = false;
            this.startText.text = "Select at least one character set!";
        }
        else
        {
            this.startButton.interactable = true;
            this.startText.text = "Start!";
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
