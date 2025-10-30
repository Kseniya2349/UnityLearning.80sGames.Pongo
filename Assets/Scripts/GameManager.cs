using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            _instance ??= new GameManager();
            return _instance;
        }
    }

    public int Score = 0;

    public readonly GameField GameField =
        new GameField(new Vector2(-8.88f, -5), new Vector2(8.88f, 5));

    private GameManager()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            Score = PlayerPrefs.GetInt("Score");
        }
    }
    
    public void LoadMainMenu()
    {
        PlayerPrefs.SetInt("Score", Score);
        SceneManager.LoadScene(0);
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ReloadGame()
    {
        Score = 0;
        LoadMainMenu();
    }
}