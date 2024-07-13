using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public static float globalSpeed = 10;
    public bool player1;
    public bool player2;
    Rigidbody2D rb2d;
    private int difficulty;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty", 0);
        switch (difficulty)
        {
            case 0:
                globalSpeed = 10;
                break;
            case 1:
                globalSpeed = 12.5f;
                break;
            case 2:
                globalSpeed = 15;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (player1)
            player1Movement();
        else if (player2)
            player2Movement();
        //Debug.Log(globalSpeed);

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
