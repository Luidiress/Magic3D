using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject TextGameover;

    public void GameOverQ()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        TextGameover.SetActive(true);
        
    }
}
