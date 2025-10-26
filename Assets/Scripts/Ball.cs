using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    
    private float _radius;

    private Vector2 _direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _direction = Vector2.one.normalized;
        _radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);

        if ((transform.position.y < GameManager.GameField.MinY + _radius && _direction.y < 0) 
            || (transform.position.y > GameManager.GameField.MaxY - _radius && _direction.y > 0))
        {
            _direction.y = -_direction.y;
        }
        
        if (transform.position.x < GameManager.GameField.MinX 
            || transform.position.x > GameManager.GameField.MaxX)
        {
            GameManager.Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var isRight = other.GetComponent<Player>().isRight;

            if ((isRight && _direction.x > 0) || (!isRight && _direction.x < 0))
            {
                _direction.x = -_direction.x;

                GameManager.Score++;
            }
            
        }
    }
}
