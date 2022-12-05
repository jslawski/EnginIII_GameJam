using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObserver : MonoBehaviour
{
    public static int score = 0;
    public static int bestStreak = 0;
    private int curStreak = 0;

    [SerializeField]
    private AudioSource resultSound;
    [SerializeField]
    private AudioSource vocalSound;
    private Dictionary<string, AudioClip> characterSounds;

    private AudioClip correctSound;
    private AudioClip incorrectSound;

    private int timeIncreaseThreshold = 5;
    private float timeSpeedIncrease = 0.4f;

    private void Start()
    {
        score = 0;
        this.correctSound = Resources.Load<AudioClip>("Audio/correctSound");
        this.incorrectSound = Resources.Load<AudioClip>("Audio/incorrectSound");
        this.SetupAudioDictionary();
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

    public void OnNotify(string character, bool result)
    {
        if (result == true)
        {
            this.IncrementScores(character);

            this.resultSound.clip = this.correctSound;
            StartCoroutine(this.PlayResultAudio(character));
            
            if (score % this.timeIncreaseThreshold == 0)
            {
                Level.timeBetweenBlocks -= this.timeSpeedIncrease;
            } 
        }
        else
        {
            this.resultSound.clip = this.incorrectSound;
            StartCoroutine(this.PlayResultAudio(character));

            if (this.curStreak > bestStreak)
            {
                bestStreak = this.curStreak;
            }

            this.curStreak = 0;            
        }
    }

    private void IncrementScores(string character)
    {
        int charScore = PlayerPrefs.GetInt(character, 0);
        charScore++;
        PlayerPrefs.SetInt(character, charScore);

        score++;
        this.curStreak++;
    }

    private IEnumerator PlayResultAudio(string characterEntry)
    {
        this.resultSound.Play();

        yield return new WaitForSeconds(0.5f);

        this.vocalSound.clip = this.characterSounds[characterEntry];
        this.vocalSound.Play();
    }
}
