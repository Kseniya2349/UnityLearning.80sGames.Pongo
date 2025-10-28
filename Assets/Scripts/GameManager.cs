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

    public void LoadMainMenu()
    {
        Score = 0;
        SceneManager.LoadScene(0);
    }
}