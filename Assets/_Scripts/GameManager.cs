using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private GameObject gameOverCanvas;
    
    private void Update()
    {        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TriggerGameOver()
    {
        this.gameOverCanvas.SetActive(true);
    }
}
