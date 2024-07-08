using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public int speed = 10;
    bool moving = false;
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb2d.velocity = Vector2.up * speed;
        else if (Input.GetKey(KeyCode.S))
            rb2d.velocity = Vector2.down * speed;
        else
            rb2d.velocity = new Vector2(0, 0);
   
    }
}
