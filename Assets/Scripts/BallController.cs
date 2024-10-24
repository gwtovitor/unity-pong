using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public GameManager gameManager;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }
        if (collisor.gameObject.CompareTag("Player") || collisor.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= 1.1f;
        }
        if (collisor.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();

            ResetBall();
        }
        if (collisor.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();

            ResetBall();
        }

    }
}
