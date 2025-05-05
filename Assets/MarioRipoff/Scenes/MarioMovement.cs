using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ☺ ♥    
    }

    void Update()
    {
        var xMove = Input.GetAxis("Horizontal");
        rb.linearVelocityX = xMove * 5f;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocityY = 5;
        }
    }
}
