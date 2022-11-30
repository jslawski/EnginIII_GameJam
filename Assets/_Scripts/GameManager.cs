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

    [SerializeField]
    private int score = 0;

    private Dictionary<string, AudioClip> characterSounds;
    private AudioSource vocalAudio;

    private void Start()
    {
        this.SetupGame();
        this.vocalAudio = GetComponent<AudioSource>();
    }

    private void SetupGame()
    {
        this.SetupAudioDictionary();
        this.StartLevel();
    }

    private void SetupAudioDictionary()
    {
        this.characterSounds = new Dictionary<string, AudioClip>();

        foreach (KeyValuePair<string, string> entry in TranslationDictionary.ENtoJP)
        {
            AudioClip foundClip = Resources.Load<AudioClip>("Audio/" + entry.Key);

            if (foundClip == null)
            {
                Debug.LogError("NULL!");
            }

            this.characterSounds.Add(entry.Key, foundClip);
        }
    }

    private void Update()
    {
        if (CharacterManager.vowel != string.Empty)
        {
            this.ProcessEntry();
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

        Debug.LogError("Processing: " + characterEntry);

        bool result = this.charStack.ProcessEntry(characterEntry);

        if (result == true)
        {
            this.score++;
        }

        this.vocalAudio.clip = this.characterSounds[characterEntry];
        this.vocalAudio.Play();

        CharacterManager.consonant = string.Empty;
        CharacterManager.vowel = string.Empty;        
    }
}
