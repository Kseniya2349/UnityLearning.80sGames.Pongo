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

    private readonly HighScoresHandler _highScoresHandler = new ();
    private int _score;

    public int GetScore()
    {
        return _score;
    }
    
    public void IncreaseScore()
    {
        _score++;
    }

    public readonly GameField GameField =
        new (new Vector2(-8.88f, -5), new Vector2(8.88f, 5));

    private GameManager()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            _score = PlayerPrefs.GetInt("Score");
        }
    }
    
    public void LoadMainMenu()
    {
        PlayerPrefs.SetInt("Score", _score);
        SceneManager.LoadScene(0);

        if (_score > 0)
        {
            _highScoresHandler.UpdateHighScores(_score);
        }
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ReloadGame()
    {
        _score = 0;
        LoadMainMenu();
    }

    public int[] GetHighScores()
    {
        return _highScoresHandler.HighScores;
    }
}