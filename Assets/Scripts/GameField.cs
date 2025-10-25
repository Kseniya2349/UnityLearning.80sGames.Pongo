using UnityEngine;

public class GameField
{
    private readonly Vector2 _bottomLeft;
    private readonly Vector2 _topRight;

    public GameField(Vector2 bottomLeft, Vector2 topRight)
    {
        _bottomLeft = bottomLeft;
        _topRight = topRight;
    }
    
    public float MinY => _bottomLeft.y;
    public float MaxY => _topRight.y;
    public float MinX => _bottomLeft.x;
    public float MaxX => _topRight.x;
}