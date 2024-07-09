using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject ballObject;
    public PlayerScript playerScript;
    public BallScript ballScript;
    int firstDirection;
    float playerSpeed;
    Rigidbody2D ballrb;
    private void Awake()
    {
        ballrb = ballObject.GetComponent<Rigidbody2D>();
        playerSpeed = playerScript.speed;
    }
    private void Start()
    {
        firstDirection = Random.Range(0, 2);
        if (firstDirection == 0)
            ballrb.velocity = Vector2.left * playerSpeed;
        else ballrb.velocity = Vector2.right * playerSpeed;
            
    }
}
