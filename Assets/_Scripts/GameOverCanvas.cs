using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI streakText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText.text = "Final Score:\n" + InputObserver.score.ToString();
        this.streakText.text = "Best Streak:\n" + InputObserver.bestStreak.ToString();
    }

    public void RetryClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenuClicked()
    {
        SceneManager.LoadScene(0);
    }
}
