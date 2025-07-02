using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocaDeCenario : MonoBehaviour
{
    [SerializeField] private AudioClip som;
    private AudioSource player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Dungeon()
    {
        SceneManager.LoadScene("Dungeon");
    }

    public void Lobby()
    {
               SceneManager.LoadScene("Lobby");
    }

    public void Menu()
        {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
