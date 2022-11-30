using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CharacterStack charStack;

    [SerializeField]
    private Transform consonantsParent;
    [SerializeField]
    private GameObject consonantPrefab;
    
    public static int score = 0;
    private int timeIncreaseThreshold = 5;
    private float timeSpeedIncrease = 0.2f;

    private Dictionary<string, AudioClip> characterSounds;
    private AudioSource gameAudio;

    [SerializeField]
    private GameObject gameOverCanvas;

    public static bool gameOver = false;

    private void Start()
    {
        this.SetupGame();
        this.gameAudio = GetComponent<AudioSource>();
    }

    private void SetupGame()
    {
        gameOver = false;
        score = 0;
        this.SetupAudioDictionary();
        this.StartLevel();
    }

    private void SetupAudioDictionary()
    {
        this.characterSounds = new Dictionary<string, AudioClip>();

        foreach (KeyValuePair<string, string> entry in TranslationDictionary.ENtoJP)
        {
            AudioClip foundClip = Resources.Load<AudioClip>("Audio/VocalSounds/" + entry.Key);
            this.characterSounds.Add(entry.Key, foundClip);
        }
    }

    private void Update()
    {
        if (CharacterManager.vowel != string.Empty)
        {
            this.ProcessEntry();
        }

        if (gameOver == true)
        {
            this.gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SetupTestLevel()
    {
        List<string> testList = new List<string>() 
        { 
            "a", "i", "u", "e", "o"            
        };
        Level.SetupNewLevel(testList, 1.0f);
    }

    private void StartLevel()
    {
        this.SetupConsonants();
        this.charStack.BeginGeneration();
    }

    private void SetupConsonants()
    {
        for (int i = 0; i < Level.activeConsonants.Count; i++)
        {
            GameObject consonantObject = Instantiate(this.consonantPrefab, this.consonantsParent);
            consonantObject.GetComponent<Consonant>().Setup(Level.activeConsonants[i]);
        }
    }

    private void ProcessEntry()
    {
        string characterEntry = CharacterManager.consonant + CharacterManager.vowel;

        bool result = this.charStack.ProcessEntry(characterEntry);

        if (result == true)
        {
            score++;

            if (score % this.timeIncreaseThreshold == 0)
            {
                Level.timeBetweenBlocks -= this.timeSpeedIncrease;
            }
        }
       
        StartCoroutine(this.PlayVocalAudio(characterEntry));

        CharacterManager.consonant = string.Empty;
        CharacterManager.vowel = string.Empty;        
    }

    private IEnumerator PlayVocalAudio(string characterEntry)
    {
        yield return new WaitForSeconds(0.5f);

        this.gameAudio.clip = this.characterSounds[characterEntry];
        this.gameAudio.Play();
    }
}
