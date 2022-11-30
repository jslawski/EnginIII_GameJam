using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText.text = "Final Score:\n" + GameManager.score.ToString();
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
