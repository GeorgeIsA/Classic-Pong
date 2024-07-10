using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] public bool onRandom;

    float playerSpeed;

    Rigidbody2D ballrb;
    private void Awake()
    {
        ballrb = ball.GetComponent<Rigidbody2D>();
        playerSpeed = PlayerScript.globalSpeed;
    }
    private void Start()
    {
        Restart();
    }
    public void Restart()
    {
        int firstDirection = Random.Range(0, 2);
        ball.transform.position = new Vector2(0, 0);
        if (firstDirection == 0 && onRandom)
            ballrb.velocity = new Vector2(1, 0) * playerSpeed;
        else
            ballrb.velocity = new Vector2(-1, 0) * playerSpeed;

    }
}
