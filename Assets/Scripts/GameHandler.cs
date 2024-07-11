using UnityEngine;
public class GameHandler : MonoBehaviour
{
    public static GameObject ball;
    public static GameObject player1;
    public static GameObject player2;
    public bool firstInstance = false;
    [SerializeField] public bool onRandom;

    float playerSpeed;

    Rigidbody2D ballrb;
    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        Time.timeScale = 0;
    }
    private void Awake()
    {

        ball = GameObject.Find("Ball");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
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
