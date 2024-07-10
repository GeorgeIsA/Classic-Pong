using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float playerY = other.gameObject.transform.position.y;
        float ballY = gameObject.transform.position.y;
        if (other.collider.CompareTag("Player"))
        {
            if (rb2d.velocity.x > 0)
                rb2d.velocity = new Vector2(1, ballY-playerY) * PlayerScript.globalSpeed;
            else if (rb2d.velocity.x < 0)
                rb2d.velocity = new Vector2(-1, ballY-playerY) * PlayerScript.globalSpeed;
        }
        else if (other.collider.CompareTag("edge"))
        {
            if (rb2d.velocity.x > 0)
                rb2d.velocity = new Vector2(1, checkY()) * PlayerScript.globalSpeed;
            else if (rb2d.velocity.x < 0)
                rb2d.velocity = new Vector2(-1, checkY()) * PlayerScript.globalSpeed;
        }
    }

    private float checkY()
    {
        if (rb2d.velocity.y > 0)
            return 1;
        else
            return -1;
    }
}
