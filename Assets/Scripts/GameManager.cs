using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
        public static int Score = 0;

        public static readonly GameField GameField =
            new GameField(new Vector2(-8.88f, -5), new Vector2(8.88f, 5));

        public static void Restart()
        {
            Score = 0;
            SceneManager.LoadScene(0);
        }
}