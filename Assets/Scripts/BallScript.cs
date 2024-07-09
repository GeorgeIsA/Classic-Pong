using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    float playerSpeed;
    public float scaleY = 10;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerSpeed = GameObject.Find("player").GetComponent<PlayerScript>().globalSpeed;
    }

    private void Update()
    {
        Debug.Log(rb2d.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float playerY = GetY(other);
        float ballY = gameObject.transform.position.y;
        if (other.collider.CompareTag("Player"))
        {
            if (rb2d.velocity.x > 0)
                rb2d.velocity = new Vector2(1, (ballY - playerY) * scaleY * 0.1f) * playerSpeed;
            else if (rb2d.velocity.x < 0)
                rb2d.velocity = new Vector2(-1, (ballY - playerY) * scaleY * 0.1f) * playerSpeed;
        }
        else if (other.collider.CompareTag("edge"))
        {
            if (rb2d.velocity.x > 0)
                rb2d.velocity = new Vector2(1, 0) * playerSpeed;
            else if (rb2d.velocity.x < 0)
                rb2d.velocity = new Vector2(-1, 0) * playerSpeed;
        }
    }

    private float GetY(Collision2D other)
    {
        return other.gameObject.transform.position.y;
    }
}
