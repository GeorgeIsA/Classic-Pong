using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    float playerSpeed;
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
    void OnCollisionEnter2D()
    {
        if (rb2d.velocity.x > 0)
            rb2d.velocity = new Vector2(1, 0) * playerSpeed;
        else if (rb2d.velocity.x < 0)
            rb2d.velocity = new Vector2 (-1, 0) * playerSpeed;
    }
}
