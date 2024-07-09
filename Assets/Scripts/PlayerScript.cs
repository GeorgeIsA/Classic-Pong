using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public static float globalSpeed = 8;
    public bool player1;
    public bool player2;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player1)
            player1Movement();
        else if (player2)
            player2Movement();
        
    }

    private void player2Movement()
        {
        if (Input.GetKey(KeyCode.W))
            rb2d.velocity = new Vector2(0, 1) * globalSpeed;
        else if (Input.GetKey(KeyCode.S))
            rb2d.velocity = new Vector2(0, -1) * globalSpeed;
        else
            rb2d.velocity = new Vector2(0, 0);
    }
    private void player1Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb2d.velocity = new Vector2(0, 1) * globalSpeed;
        else if (Input.GetKey(KeyCode.DownArrow))
            rb2d.velocity = new Vector2(0, -1) * globalSpeed;
        else
            rb2d.velocity = new Vector2(0, 0);
    }
}
