using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    
    private float radius;

    private Vector2 direction;
    private Vector2 bottomLeft;
    private Vector2 topRight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if ((transform.position.y < bottomLeft.y + radius && direction.y < 0) 
            || (transform.position.y > topRight.y - radius && direction.y > 0))
        {
            direction.y = -direction.y;
        }
        
        // Game over
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var isRight = other.GetComponent<Player>().isRight;

            if ((isRight && direction.x > 0) || (!isRight && direction.x < 0))
            {
                direction.x = -direction.x;
            }
            
        }
    }
}
