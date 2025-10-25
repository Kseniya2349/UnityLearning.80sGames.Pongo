using UnityEngine;

public class GameManager
{
        public static int Score = 0;

        public static GameField GameField =
            new GameField(new Vector2(-8.88f, -5), new Vector2(8.88f, 5));
}