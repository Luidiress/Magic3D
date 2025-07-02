using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject textoTextoVitoria;
    [SerializeField] GameObject textoTextoDerrota;
    public GameObject gameOverUI;
    public GameObject TextGameover;
    private object player;

    public void GameOverQ()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        TextGameover.SetActive(true);
        
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
