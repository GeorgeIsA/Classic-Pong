using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public int speed = 10;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb2d.velocity = Vector2.up * speed;
        else if (Input.GetKey(KeyCode.S))
            rb2d.velocity = Vector2.down * speed;
        else
            rb2d.velocity = new Vector2(0, 0);
   
    }
}
