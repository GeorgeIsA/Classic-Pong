using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public int globalSpeed = 10;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move the player up or down
        if (Input.GetKey(KeyCode.W))
            rb2d.velocity = Vector2.up * globalSpeed;
        else if (Input.GetKey(KeyCode.S))
            rb2d.velocity = Vector2.down * globalSpeed;
        else
            rb2d.velocity = new Vector2(0, 0);
    }
}
